using System.Collections.Generic;
using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Dominio;

namespace Exemplo.Aplicacao.Users.Query
{
    public class AllUserQueryHandler : IQueryHandler<AllUserQuery, IEnumerable<User>>
    {
        private readonly IRepository<User> _repository;

        public AllUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> Execute(AllUserQuery query)
        {
            return  _repository.Get();
        }
    }
}