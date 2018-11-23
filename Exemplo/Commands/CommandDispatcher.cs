using System;
using Exemplo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async void Dispatch<T>(T command) where T : ICommand
        {

            if (command == null)
                throw new ArgumentNullException("command");
            try
            {
                var handler = (ICommandHandler<T>)serviceProvider.GetService(typeof(ICommandHandler<T>));
                
                handler.Execute(command);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not resolve handler for ICommandHandler<{0}>", typeof(T).Name), ex);
            }
        }
    }
}