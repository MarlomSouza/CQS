using System.Collections;
using System.Collections.Generic;
using Exemplo.Domain;
using Exemplo.Query.Interface;

namespace Exemplo.Query
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