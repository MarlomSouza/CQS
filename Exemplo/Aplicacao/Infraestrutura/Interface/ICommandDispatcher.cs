using Exemplo.Aplicacao.Commands.Interface;

namespace Exemplo.Aplicacao.Infraestrutura.Interface
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
    }
}
