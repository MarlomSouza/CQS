using Exemplo.Aplicacao.Commands.Interface;

namespace Exemplo.Aplicacao.Infraestrutura.Interface
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
