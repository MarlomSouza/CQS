using System;
using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Dominio;

namespace Exemplo.Aplicacao.Users.Commands
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IRepository<Entity> _repository;

        public CreateUserHandler(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateUser createUser)
        {
            var user = new User(createUser.Name, createUser.Email, createUser.Password);
            _repository.Save(user);
            Console.WriteLine("SALVOU NO BANCO");
        }
    }
}