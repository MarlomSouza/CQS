using Exemplo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Exemplo.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}