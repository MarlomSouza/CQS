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

        public void Execute(CreateUser createUser)
        {
            var user = new User(createUser.Nickname, createUser.Email, createUser.Password);
            repository.Save(user);
        }
    }
}