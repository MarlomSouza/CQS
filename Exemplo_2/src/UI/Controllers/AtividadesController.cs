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

        [HttpGet]
        [Route("abertas")]
        public ActionResult<AtividadesDto> Get()
        {
            var listarAtividade = new ListarAtividades() { Concluida = false };
            return _dispatcher.Execute<ListarAtividades, AtividadesDto>(listarAtividade);
        }

        [HttpGet]
        [Route("concluidas")]
        public ActionResult<AtividadesDto> GetAtividadeConcluida()
        {
            var listarAtividade = new ListarAtividades() { Concluida = true };
            return _dispatcher.Execute<ListarAtividades, AtividadesDto>(listarAtividade);
        }

        [HttpPut]
        [Route("{id}/concluir")]
        public void PutConcluirAtividade(int id)
        {
            var concluirAtividade = new ConcluirAtividade() { IdAtividade = id };
            _commandDispatcher.Dispatch(concluirAtividade);
        }

        [HttpPut]
        [Route("{id}/desconcluir")]
        public void PutDesconcluirAtividade(int id)
        {
            var desconcluirAtividade = new DesconcluirAtividade() { IdAtividade = id };
            _commandDispatcher.Dispatch(desconcluirAtividade);
        }

        [HttpPut]
        [Route("{id}")]
        public void PutAtividade(int id, AlterarAtividade alterarAtividade)
        {
            alterarAtividade.Id = id;
            _commandDispatcher.Dispatch(alterarAtividade);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var removerAtividade = new RemoverAtividade() { IdAtividade = id };
            _commandDispatcher.Dispatch(removerAtividade);
        }
    }
}