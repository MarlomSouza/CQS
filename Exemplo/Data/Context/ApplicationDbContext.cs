using Exemplo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Exemplo.Data.Context
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}