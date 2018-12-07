using Aplicacao.Infraestrutura.Query;
using Dominio._Base;

namespace Aplicacao.Atividades.Query
{
    public class ListarAtividadesHandler : IQueryHandler<ListarAtividades, AtividadesDto>
    {
        private readonly IAtividadeService _service;
        public ListarAtividadesHandler(IAtividadeService service)
        {
            _service = service;
        }

        public AtividadesDto Execute(ListarAtividades query)
        {

            return null;
        }
    }
}