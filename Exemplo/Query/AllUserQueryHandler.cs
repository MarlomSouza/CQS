using System.Collections;
using System.Collections.Generic;
using Exemplo.Domain;
using Exemplo.Query.Interface;

namespace Exemplo.Query
{
    public class AllUserQueryHandler : IQueryHandler<AllUserQuery, IEnumerable<User>>
    {
        public IEnumerable<User> Execute(AllUserQuery query)
        {
            var usuario_1 = new User("Marlom", "email@email.com", "senha.123");
            var usuario_2 = new User("Ciclano", "ciclano@email.com", "senha.321");
            var usuario_3 = new User("Funalo", "fulano@email.com", "senha.231");
            return new User[]{usuario_1, usuario_2, usuario_3};
        }
    }
}