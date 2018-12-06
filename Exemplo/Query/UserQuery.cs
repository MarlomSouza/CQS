using Exemplo.Domain;
using Exemplo.Query.Interface;

namespace Exemplo.Query
{
    public class UserQuery : IQuery<User>
    {
        public int Id { get; set; }
    }
}