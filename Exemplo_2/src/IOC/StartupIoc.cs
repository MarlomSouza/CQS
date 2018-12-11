using Aplicacao.Atividades.Command;
using Aplicacao.Atividades.Query;
using Aplicacao.Atividades.Service;
using Aplicacao.Infraestrutura.Command;
using Aplicacao.Infraestrutura.Query;
using Dominio._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistencia;
using Persistencia._Base;

namespace IOC
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAtividadeService), typeof(AtividadeService));
            services.AddScoped(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            services.AddScoped(typeof(ICommandHandler<CriarAtividade>), typeof(CriarAtividadeHandler));
            services.AddScoped(typeof(ICommandHandler<ConcluirAtividade>), typeof(ConcluirAtividadeHandler));
            services.AddScoped(typeof(ICommandHandler<AlterarAtividade>), typeof(AlterarAtividadeHandler));
            services.AddScoped(typeof(IQueryDispatcher), typeof(QueryDispatcher));
            services.AddScoped(typeof(IQueryHandler<ListarAtividades, AtividadesDto>), typeof(ListarAtividadesHandler));
        }
    }
}