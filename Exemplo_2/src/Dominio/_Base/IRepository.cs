using System.Collections.Generic;
using Dominio.Entities;

namespace Dominio._Base
{
    public interface IRepository<TEntidade> where TEntidade : Entity
    {
        TEntidade ObterPorId(int id);
        IEnumerable<TEntidade> Listar();
        void Adicionar(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Remover(TEntidade entidade);
    }
}