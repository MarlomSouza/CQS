using System.Threading.Tasks;
using Exemplo.Domain;
using Exemplo.Repository;

namespace Exemplo.Commands
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IRepository<User> repository;
        public CreateUserHandler(UserRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(CreateUser command)
        {
            var user = new User(command.Nickname, command.Email, command.Password);
            repository.Save(user);
        }
    }
}