using System.Collections;
using Dominio._Base;
using Dominio.Entities;
using meuapp.unitTests.Builders;
using Moq;
using Aplicacao.Atividades.Service;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using System;
using Dominio.Exceptions;

namespace meuapp.unitTests.Service
{
    public class AtividadeServiceTeste
    {
        private IEnumerable<Atividade> atividades = new Atividade[] { AtividadeBuilder.Novo().Build(),
            AtividadeBuilder.Novo().Build(), AtividadeBuilder.Novo().JaConcluida(true).Build(),
            AtividadeBuilder.Novo().Build(), AtividadeBuilder.Novo().Build(),
            AtividadeBuilder.Novo().JaConcluida(true).Build(), AtividadeBuilder.Novo().Build(),
            AtividadeBuilder.Novo().Build(), AtividadeBuilder.Novo().Build()};
        private object atividadeEsperada;
        private readonly AtividadeService _service;
        private readonly Mock<IRepository<Atividade>> _repository;

        public AtividadeServiceTeste()
        {
            _repository = new Mock<IRepository<Atividade>>();
            _service = new AtividadeService(_repository.Object);
        }

        [Fact]
        public void Deve_lista_atividade_concluidas()
        {
            //Given
            _repository.Setup(r => r.Listar()).Returns(atividades);
            var atividadesEsperadas = atividades.Where(atividades => atividades.Concluida);
            //When
            var atividadesEncontradas = _service.ListaAtividadeConcluida();
            //Then
            Assert.Equal(atividadesEsperadas, atividadesEncontradas);
        }

        [Fact]
        public void Deve_lista_atividade_abertas()
        {
            //Given
            _repository.Setup(r => r.Listar()).Returns(atividades);
            var atividadeEsperada = atividades.Where(atividade => !atividade.Concluida);
            //When
            var atividaesEncontrada = _service.ListaAtividadeEmAberto();
            //Then
            Assert.Equal(atividadeEsperada, atividaesEncontrada);
        }

        [Fact]
        public void Deve_salvar_atividade_alterada()
        {
            //Given
            const int id = 8;
            var atividadeEsperada = AtividadeBuilder.Novo()
            .ComId(id)
            .ComTitulo("Titulo 1")
            .ComDescricao("Descrição padrão")
            .ComTipoAtividade(TipoAtividade.Desenvolvimento).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(AtividadeBuilder.Novo().ComId(id).Build());
            //When
            _service.AlterarAtividade(id, atividadeEsperada.Titulo, atividadeEsperada.Descricao, atividadeEsperada.Tipo);
            //Then
            _repository.Verify(r => r.Alterar(It.Is<Atividade>(atividade => atividade.Titulo == atividadeEsperada.Titulo)), Times.Once);
        }

        [Fact]
        public void Deve_alterar_uma_atividade_para_concluida()
        {
            //Given
            const int id = 39;
            var atividadeEsperada = AtividadeBuilder.Novo().ComId(id).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(atividadeEsperada);
            //When
            _service.ConcluirAtividade(id);
            //Then
            _repository.Verify(r => r.Alterar(It.Is<Atividade>(atividade =>
            atividade.Titulo == atividadeEsperada.Titulo &&
            atividade.Concluida)), Times.Once);
        }

        [Fact]
        public void Deve_alterar_uma_atividade_para_inconcluida()
        {
            //Given
            const int id = 97;
            var atividadeEsperada = AtividadeBuilder.Novo().ComId(id).JaConcluida(true).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(atividadeEsperada);
            //When
            _service.DesconcluirAtividade(id);
            //Then
            _repository.Verify(r => r.Alterar(It.Is<Atividade>(atividade =>
            atividade.Titulo == atividadeEsperada.Titulo && !atividade.Concluida)), Times.Once);
        }

        [Fact]
        public void Deve_salvar_uma_atividade()
        {
            //Given
            const string titulo = "Apenas mais um titulo";
            const string descricao = "Essa é uma descricao para um teste.";
            TipoAtividade tipoAtividade = TipoAtividade.Desenvolvimento;
            //When
            _service.AdicionarAtividade(titulo, descricao, tipoAtividade);
            //Then
            _repository.Verify(r => r.Adicionar(It.Is<Atividade>(atividade =>
           atividade.Titulo == titulo &&
           atividade.Descricao == descricao &&
           atividade.Tipo == tipoAtividade)), Times.Once);
        }

        [Fact]
        public void Deve_excluir_uma_atividade()
        {
            //Given
            const string titulo = "Outro titulo";
            const int id = 323;
            TipoAtividade tipoAtividade = TipoAtividade.Manutencao;
            var atividadeEsperada = AtividadeBuilder.Novo()
            .ComTitulo(titulo)
            .ComTipoAtividade(tipoAtividade)
            .ComId(id).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(atividadeEsperada);
            //When
            _service.RemoverAtividade(id);
            //Then
            _repository.Verify(r => r.Remover(It.Is<Atividade>(atividade =>
            atividade.Titulo == titulo &&
                atividade.Id == id)), Times.Once);
        }

        [Fact]
        public void Nao_Deve_excluir_uma_atividade()
        {
            //Given
            const string titulo = "Outro titulo";
            const int id = 323;
            TipoAtividade tipoAtividade = TipoAtividade.ManutencaoUrgente;
            var atividadeEsperada = AtividadeBuilder.Novo()
            .ComTitulo(titulo)
            .ComTipoAtividade(tipoAtividade)
            .ComId(id).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(atividadeEsperada);
            //When
            Action act = () => _service.RemoverAtividade(id);
            //Then
            Assert.Throws<DomainException>(act);
            _repository.Verify(r => r.Remover(It.Is<Atividade>(atividade =>
            atividade.Titulo == titulo && atividade.Id == id)), Times.Never);

        }

        [Fact]
        public void Deve_obter_uma_atividade()
        {
            //Given
            const int id = 1233;
            var atividadeEsperada = AtividadeBuilder.Novo().ComId(id).Build();
            _repository.Setup(r => r.ObterPorId(id)).Returns(atividadeEsperada);
            //When
            var atividade = _service.ObterPorId(id);
            //Then
            Assert.Equal(atividadeEsperada, atividade);
        }

        [Fact]
        public void Deve_disparar_excecao_quando_nao_existir_usuario()
        {
            //Given
            const string mensagemEsperada = "Usuario inválido";
            const int id = 234;
            //When
            Action act = () => _service.ObterPorId(id);
            //Then
            var mensagem = Assert.Throws<DomainException>(act).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}