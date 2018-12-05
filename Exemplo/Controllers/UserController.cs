using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exemplo.Commands;
using Exemplo.Domain;
using Exemplo.Query;
using Exemplo.Query.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public CreateUser Get(AllUserQuery allUser)
        {
            _queryDispatcher.Execute<AllUserQuery,IEnumerable<User>>(allUser);

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            _commandDispatcher.Dispatch(createUser);
            return Ok();
        }

        [HttpDelete]
        public void Delete([FromBody] DeleteUser delete){
            _commandDispatcher.Dispatch(delete);
        }
    }
}