using Aplicacao.Atividades.Query;
using Aplicacao.Infraestrutura.Query;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly IQueryDispatcher _dispatcher;

        public AtividadesController(IQueryDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            var listarAtividade = new ListarAtividades();
            _dispatcher.Execute<ListarAtividades, AtividadesDto>(listarAtividade);
            return null;
        }
    }
}