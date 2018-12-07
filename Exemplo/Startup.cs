using Exemplo.Aplicacao.Infraestrutura;
using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Aplicacao.Users.Commands;
using Exemplo.Aplicacao.Users.Query;
using Exemplo.Dominio;
using Exemplo.Persistence;
using Exemplo.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Exemplo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped(typeof(IRepository<Entity>), typeof(Repository<Entity>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            services.AddScoped(typeof(ICommandHandler<CreateUser>), typeof(CreateUserHandler));
            services.AddScoped(typeof(ICommandHandler<DeleteUser>), typeof(DeleteUserHandler));
            services.AddScoped(typeof(IQueryDispatcher), typeof(QueryDispatcher));
            services.AddScoped(typeof(IQueryHandler<AllUserQuery, IEnumerable<User>>), typeof(AllUserQueryHandler));
            services.AddScoped(typeof(IQueryHandler<UserQuery,User>), typeof(UserQueryHandler));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
