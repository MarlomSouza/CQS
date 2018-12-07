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

        public async void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException("command");

            try
            {
                var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(typeof(ICommandHandler<TCommand>));

                handler.Execute(command);
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not resolve handler for ICommandHandler<{typeof(TCommand).Name}>", ex);
            }
        }
    }
}