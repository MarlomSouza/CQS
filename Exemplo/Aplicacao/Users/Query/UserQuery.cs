using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Dominio;

namespace Exemplo.Aplicacao.Users.Query
{
    public class UserQuery : IQuery<User>
    {
        public int Id { get; set; }
    }
}