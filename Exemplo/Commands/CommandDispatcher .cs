using System;

namespace Exemplo.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandDispatcher(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void Execute<TCommand>(TCommand command)  where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (_commandDispatcher == null)
            {
                throw new Exception("Erro");
            }

            _commandDispatcher.Execute(command);
        }
    }
}