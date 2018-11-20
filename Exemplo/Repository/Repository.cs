using System.Collections.Generic;
using System.Linq;
using Exemplo.Data.Context;
using Exemplo.Domain;

namespace Exemplo.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public TEntity Get(int id) => context.Set<TEntity>().SingleOrDefault(entity => entity.Id == id);

        public IEnumerable<TEntity> Get() => context.Set<TEntity>().AsEnumerable();

        public void Save(TEntity entity)
        {
            context.Add<TEntity>(entity);
            context.SaveChanges();
        }
    }
}