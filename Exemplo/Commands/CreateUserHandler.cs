using System;
using System.Threading.Tasks;
using Exemplo.Domain;
using Exemplo.Repository;

namespace Exemplo.Commands
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IRepository<Entity> repository;

        public CreateUserHandler(IRepository<Entity> repository)
        {
            this.repository = repository;
        }

        public void Execute(CreateUser createUser)
        {
            var user = new User(createUser.Name, createUser.Email, createUser.Password);
            repository.Save(user);
            Console.WriteLine("SALVOU NO BANCO");
        }
    }
}