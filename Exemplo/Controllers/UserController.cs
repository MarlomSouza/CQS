using System.Threading.Tasks;
using Exemplo.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;


        public UserController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            _commandDispatcher.Dispatch(createUser);
            return Ok();
        }
    }
}