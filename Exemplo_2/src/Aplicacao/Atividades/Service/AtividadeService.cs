using System;
using System.Collections.Generic;
using System.Linq;
using Dominio._Base;
using Dominio.Entities;
using Dominio.Exceptions;

namespace Aplicacao.Atividades.Service
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IRepository<Atividade> _repository;

        public AtividadeService(IRepository<Atividade> repository)
        {
            _repository = repository;
        }

        public void AdicionarAtividade(string titulo, string descricao, TipoAtividade tipo)
        {
            var atividade = new Atividade(titulo, descricao, tipo, DateTime.Now);
            _repository.Adicionar(atividade);
        }

        public void ConcluirAtividade(int id)
        {
            var atividade = ObterPorId(id);
            atividade.Concluir();
            _repository.Alterar(atividade);
        }

        public void DesconcluirAtividade(int id)
        {
            var atividade = ObterPorId(id);
            atividade.Desconcluir();
            _repository.Alterar(atividade);
        }

        public void AlterarAtividade(int id, string titulo, string descricao, TipoAtividade tipo)
        {
            var atividade = ObterPorId(id);
            atividade.Alterar(titulo, descricao, tipo, DateTime.Now);
            _repository.Alterar(atividade);
        }

        public IEnumerable<Atividade> ListaAtividadeConcluida()
        {
            return _repository.Listar().Where(atividade => atividade.Concluida);
        }

        public IEnumerable<Atividade> ListaAtividadeEmAberto()
        {
            return _repository.Listar().Where(atividade => !atividade.Concluida);
        }

        public void RemoverAtividade(int id)
        {
            var atividade = ObterPorId(id);
            if (atividade.PodeExcluir())
                _repository.Remover(atividade);
        }

        public Atividade ObterPorId(int id)
        {
            var atividade = _repository.ObterPorId(id);
            DomainException.Quando(atividade == null, "Usuario inválido");
            return atividade;
        }
    }
}