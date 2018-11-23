using System;
using Exemplo.Domain;

namespace Exemplo.Commands
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