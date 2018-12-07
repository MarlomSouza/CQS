using Exemplo.Aplicacao.Commands.Interface;

namespace Exemplo.Aplicacao.Users.Commands
{
    public class CreateUser : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}