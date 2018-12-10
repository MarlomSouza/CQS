using Aplicacao.Atividades.Command;
using Aplicacao.Atividades.Query;
using Aplicacao.Infraestrutura.Command;
using Aplicacao.Infraestrutura.Query;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public AtividadesController(IQueryDispatcher dispatcher, ICommandDispatcher commandDispatcher)
        {
            _dispatcher = dispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public void Post([FromBody] CriarAtividade criarAtividade)
        {
            _commandDispatcher.Dispatch(criarAtividade);
        }

        // GET
        [HttpGet]
        [Route("/aberta")]
        public ActionResult<AtividadesDto> Get()
        {
            var listarAtividade = new ListarAtividades();
            return _dispatcher.Execute<ListarAtividades, AtividadesDto>(listarAtividade);
        }
    }
}