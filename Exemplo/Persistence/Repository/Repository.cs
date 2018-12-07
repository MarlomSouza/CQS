using System.Collections.Generic;
using System.Linq;
using Exemplo.Dominio;

namespace Exemplo.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public TEntity Get(int id) => _context.Set<TEntity>().SingleOrDefault(entity => entity.Id == id);

        public IEnumerable<TEntity> Get() => _context.Set<TEntity>().AsEnumerable();

        public void Save(TEntity entity)
        {
            _context.Add<TEntity>(entity);
            _context.SaveChanges();
        }
    }
}