using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Dominio;

namespace Exemplo.Aplicacao.Users.Query
{
    public class UserQueryHandler : IQueryHandler<UserQuery, User>
    {
        private readonly IRepository<User> _repository;

        public UserQueryHandler(IRepository<User> repository )
        {
            _repository = repository;
        }

        public User Execute(UserQuery query)
        {
            return _repository.Get(query.Id);
        }
    }
}