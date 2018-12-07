using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Atividade> Atividades { get; set; }
    }
}