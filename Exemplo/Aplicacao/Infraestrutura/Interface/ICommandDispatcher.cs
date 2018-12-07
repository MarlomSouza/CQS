using Exemplo.Aplicacao.Commands.Interface;

namespace Exemplo.Aplicacao.Infraestrutura.Interface
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
