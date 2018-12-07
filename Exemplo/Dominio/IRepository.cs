using System.Collections.Generic;

namespace Exemplo.Dominio
{
    public interface IRepository<TEntity>
    {
        void Save(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        void Delete(TEntity entity);
    }
}