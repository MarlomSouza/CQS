using System;
using Exemplo.Domain;

namespace Exemplo.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Func<Type, object> _resolver;

        public CommandDispatcher(Func<Type, object> resolver)
        {
            _resolver = resolver;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            ICommandHandler<T> handler;
            try
            {
                handler = (ICommandHandler<T>)_resolver(typeof(ICommandHandler<T>));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not resolve handler for ICommandHandler<{0}>", typeof(T).Name), ex);
            }

            if (command == null)
                throw new ArgumentNullException("command");

            handler.Execute(command);
        }
    }
}