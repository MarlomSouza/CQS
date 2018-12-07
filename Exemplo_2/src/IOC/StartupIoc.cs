using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistencia;

namespace IOC
{
    public static class StartupIoc
    {
         public static void ConfigureServices(IServiceCollection services, IConfiguration configuration){
             services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}