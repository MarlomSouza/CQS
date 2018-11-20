using Exemplo.Data.Context;
using Exemplo.Domain;

namespace Exemplo.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}