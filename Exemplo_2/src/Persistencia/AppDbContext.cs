using Dominio.Entities;
using JetBrains.Annotations;
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