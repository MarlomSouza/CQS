using System;
using Exemplo.Aplicacao.Commands.Interface;
using Exemplo.Aplicacao.Infraestrutura.Interface;

namespace Exemplo.Aplicacao.Infraestrutura
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async void Dispatch<T>(T command) where T : ICommand
        {

            if (command == null)
                throw new ArgumentNullException("command");

            try
            {
                var handler = (ICommandHandler<T>)_serviceProvider.GetService(typeof(ICommandHandler<T>));
                
                handler.Execute(command);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not resolve handler for ICommandHandler<{0}>", typeof(T).Name), ex);
            }
        }
    }
}