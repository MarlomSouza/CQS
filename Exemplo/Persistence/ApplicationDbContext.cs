using Exemplo.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Exemplo.Persistence
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}