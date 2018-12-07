using Exemplo.Aplicacao.Commands.Interface;

namespace Exemplo.Aplicacao.Users.Commands
{
    public class DeleteUser : ICommand
    {
        public int Id { get; set; }
    }
}