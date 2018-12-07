using Exemplo.Aplicacao.Commands;
using Exemplo.Aplicacao.Commands.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exemplo.Aplicacao.Infraestrutura.Interface;
using Exemplo.Aplicacao.Users.Commands;
using Exemplo.Aplicacao.Users.Query;
using Exemplo.Dominio;

namespace Exemplo.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var allUser = new AllUserQuery();
            var users = _queryDispatcher.Execute<AllUserQuery, IEnumerable<User>>(allUser);
            return users;
        }

        [HttpGet("{Id}")]
        public User Get(int id)
        {
            var query = new UserQuery { Id = id };
            var user = _queryDispatcher.Execute<UserQuery, User>(query);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            _commandDispatcher.Dispatch(createUser);
            return Ok();
        }

        [HttpDelete]
        public void Delete([FromBody] DeleteUser delete)
        {
            _commandDispatcher.Dispatch(delete);
        }
    }
}