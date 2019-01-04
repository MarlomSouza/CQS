using System;
using Dominio.Exceptions;

namespace Aplicacao.Infraestrutura.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException("command");

            try
            {
                var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
                handler.Execute(command);
            }
             catch (DomainException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not resolve handler for ICommandHandler<{0}>", typeof(TCommand).Name), ex);
            }
        }
    }
}