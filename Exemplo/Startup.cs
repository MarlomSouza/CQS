using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo.Commands;
using Exemplo.Data.Context;
using Exemplo.Domain;
using Exemplo.Query;
using Exemplo.Query.Interface;
using Exemplo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

            services.AddScoped(typeof(IRepository<Entity>), typeof(Repository<Entity>));
            services.AddScoped(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            services.AddScoped(typeof(IQueryDispatcher), typeof(QueryDispatcher));
            services.AddScoped(typeof(IQueryHandler<AllUserQuery, IEnumerable<User>>), typeof(AllUserQueryHandler));
            services.AddScoped(typeof(ICommandHandler<CreateUser>), typeof(CreateUserHandler));
            services.AddScoped(typeof(ICommandHandler<DeleteUser>), typeof(DeleteUserHandler));

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
