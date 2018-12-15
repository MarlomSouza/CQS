using System;
using System.Collections.Generic;
using Dominio.Entities;
using Dominio.Exceptions;
using Moq;
using Xunit;

namespace meuapp.unitTests.ApplicationCore.Entities
{
    public class AtividadeTeste
    {
        private const string descricao = "descricao";
        private const string titulo = "Titulo 1";
        private static DateTime data = new DateTime(2018, 10, 10);

        [Fact]
        public void Deve_criar_uma_atividade_com_titulo()
        {
            //Given
            const string tituloEsperado = "Titulo 2";
            //When
            var atividade = new Atividade(tituloEsperado, descricao, TipoAtividade.Desenvolvimento, data);
            //Then
            Assert.Equal(tituloEsperado, atividade.Titulo);
        }

        [Fact]
        public void Deve_criar_uma_atividade_com_descricao()
        {
            //Given
            const string descricaoEsperada = "descricao da atividade";
            //When
            var atividade = new Atividade(titulo, descricaoEsperada, TipoAtividade.Desenvolvimento, data);
            //Then
            Assert.Equal(descricaoEsperada, atividade.Descricao);
        }

        [Theory]
        [InlineData(TipoAtividade.Desenvolvimento)]
        [InlineData(TipoAtividade.Atendimento)]
        [InlineData(TipoAtividade.Manutencao)]
        [InlineData(TipoAtividade.ManutencaoUrgente)]
        public void Deve_criar_uma_atividade_com_tipo(TipoAtividade tipo)
        {
            //When
            var ativdade = new Atividade("titulo", descricao, tipo, data);
            //Then
            Assert.Equal(tipo, ativdade.Tipo);
        }

        [Fact]
        public void Nao_deve_criar_atividade_sem_titulo()
        {
            //Given
            const string mensagemEsperada = "Não é permitido criar atividade com titulo inválido";
            //When
            Action testCode = () => new Atividade("", descricao, TipoAtividade.Desenvolvimento, data);
            //Then
            var erro = Assert.Throws<DomainException>(testCode);
            Assert.Equal(mensagemEsperada, erro.Message);
        }

        [Fact]
        public void Deve_alterar_o_titulo_de_uma_atividade()
        {
            //Given
            const string tituloEsperado = "Novo Titulo";
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Manutencao, data);
            //When
            atividade.Alterar(tituloEsperado, descricao, TipoAtividade.Atendimento, data);
            //Then
            Assert.Equal(tituloEsperado, atividade.Titulo);
        }

        [Fact]
        public void Deve_alterar_a_descricao_de_uma_atividade()
        {
            //Given
            const string descricaoEsperada = "essa é a nova descricao que é esperada";
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Manutencao, data);
            //When
            atividade.Alterar(titulo, descricaoEsperada, TipoAtividade.Atendimento, data);
            //Then
            Assert.Equal(descricaoEsperada, atividade.Descricao);
        }

        [Fact]
        public void Deve_alterar_o_tipo_de_uma_atividade()
        {
            //Given
            var tipoEsperado = TipoAtividade.Manutencao;
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Desenvolvimento, data);
            //When
            atividade.Alterar(titulo, descricao, tipoEsperado, data);
            //Then
            Assert.Equal(tipoEsperado, atividade.Tipo);
        }

        [Fact]
        public void Nao_deve_alterar_titulo_quando_ele_for_invalido()
        {
            //Given
            const string tituloEsperado = "Meu titulo";
            var atividade = new Atividade(tituloEsperado, descricao, TipoAtividade.Desenvolvimento, data);
            //When
            atividade.Alterar(null, descricao, TipoAtividade.Desenvolvimento, data);
            //Then
            Assert.Equal(tituloEsperado, atividade.Titulo);
        }

        [Fact]
        public void Nao_deve_alterar_descricao_quando_ele_for_invalido()
        {
            //Given
            const string descricaoEsperada = "Meu titulo";
            var atividade = new Atividade(titulo, descricaoEsperada, TipoAtividade.Desenvolvimento, data);
            //When
            atividade.Alterar(titulo, null, TipoAtividade.Desenvolvimento, data);
            //Then
            Assert.Equal(descricaoEsperada, atividade.Descricao);
        }


        [Fact]
        public void Nao_deve_alterar_atividade_de_manutencao_urgente_na_sexta_feira_apos_as_13h()
        {
            //Given
            const string mensagemEsperada = "Não pode alterar atividade para manutenção urgente após as 13h da sexta-feira";
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Atendimento, data);
            var dataInvalida = new DateTime(2018, 10, 12, 13, 00, 00);
            //When
            Action act = () => atividade.Alterar(titulo, descricao, TipoAtividade.ManutencaoUrgente, dataInvalida);
            //Then
            var erro = Assert.Throws<DomainException>(act);
            Assert.Equal(mensagemEsperada, erro.Message);
        }

        [Theory]
        [InlineData(TipoAtividade.ManutencaoUrgente)]
        [InlineData(TipoAtividade.Atendimento)]
        [InlineData(TipoAtividade.Manutencao)]
        [InlineData(TipoAtividade.Desenvolvimento)]
        public void Deve_marcar_atividade_como_concluida(TipoAtividade tipo)
        {
            //Given
            const string descricaoValida = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry.
            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley.";

            var atividade = new Atividade(titulo, descricaoValida, tipo, data);
            //When
            atividade.Concluir();
            //Then
            Assert.True(atividade.Concluida);
        }

        [Fact]
        public void Deve_iniciar_uma_atividade_sem_estar_concluida()
        {
            //Given
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Desenvolvimento, data);
            //Then
            Assert.False(atividade.Concluida);
        }

        [Fact]
        public void Deve_deixar_uma_atividade_concluida_como_inconcluida()
        {
            //Given
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Desenvolvimento, data);
            atividade.Concluir();
            //When
            atividade.Desconcluir();
            //Then
            Assert.False(atividade.Concluida);
        }

        [Theory]
        [InlineData(TipoAtividade.ManutencaoUrgente)]
        [InlineData(TipoAtividade.Atendimento)]
        public void Nao_deve_concluir_atividade_com_quantidade_invalida_de_caracter(TipoAtividade tipo)
        {
            //Given
            const string mensagemEsperada = "Quantidade de caracteres inferior a 50";
            var atividade = new Atividade(titulo, descricao, tipo, data);
            //When
            Action act = () => atividade.Concluir();
            //Then
            var erro = Assert.Throws<DomainException>(act);
            Assert.Equal(mensagemEsperada, erro.Message);
            Assert.False(atividade.Concluida);
        }


        [Fact]
        public void Nao_deve_criar_atividade_de_manutencao_urgente_na_sexta_feira_apos_as_13h()
        {
            //Given
            var dataInvalida = new DateTime(2018, 11, 30, 14, 00, 00);
            const string mensagemEsperada = "Não pode criar atividade do tipo manutenção urgente após as 13h da sexta-feira";
            //When
            Action act = () => new Atividade(titulo, descricao, TipoAtividade.ManutencaoUrgente, dataInvalida);
            //Then
            var erro = Assert.Throws<DomainException>(act);
            Assert.Equal(mensagemEsperada, erro.Message);
        }

        [Theory]
        [InlineData(TipoAtividade.Manutencao)]
        [InlineData(TipoAtividade.Atendimento)]
        [InlineData(TipoAtividade.Desenvolvimento)]
        public void Deve_criar_atividade_na_sexta_feita_apos_as_13h(TipoAtividade tipoEsperado)
        {
            //Given
            var dataInvalida = new DateTime(2018, 11, 30, 14, 00, 00);
            //When
            var atividade = new Atividade(titulo, descricao, tipoEsperado, dataInvalida);
            //Then
            Assert.Equal(tipoEsperado, atividade.Tipo);
        }

        [Fact]
        public void Nao_deve_permitir_excluir_uma_atividade_do_tipo_manutencao_urgente()
        {
            //Given
            const string mensagemEsperada = "Não pode excluir atividade que seja do tipo manutação urgente";
            var atividade = new Atividade(titulo, descricao, TipoAtividade.ManutencaoUrgente, data);
            //When
            Action act = () => atividade.PodeExcluir();
            //Then
            var erro = Assert.Throws<DomainException>(act);
            Assert.Equal(mensagemEsperada, erro.Message);
        }

        [Fact]
        public void Deve_permitir_excluir_atividade()
        {
            //When
            var atividade = new Atividade(titulo, descricao, TipoAtividade.Atendimento, data);
            //Then
            Assert.True(atividade.PodeExcluir());
        }

    }
}