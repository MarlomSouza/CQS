using System.Threading.Tasks;
using Exemplo.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public BooksController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {



            return Ok();
        }
    }
}