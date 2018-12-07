using System;
using Exemplo.Aplicacao.Infraestrutura.Interface;

namespace Exemplo.Aplicacao.Users.Commands
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        public DeleteUserHandler()
        {
        }

        public void Execute(DeleteUser command)
        {
            Console.WriteLine("APAGOU DO BANCO");
        }
    }
}