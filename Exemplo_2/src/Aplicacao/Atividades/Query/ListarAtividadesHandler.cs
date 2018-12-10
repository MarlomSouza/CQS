using System.Linq;
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
            var atividades = new AtividadesDto()
            {
                Atividades = _service.ListaAtividadeEmAberto().Select(atividade =>
                new AtividadeDto
                {
                    Titulo = atividade.Titulo,
                    Descricao = atividade.Descricao,
                    Tipo = atividade.Tipo.ToString(),
                    Concluida = atividade.Concluida
                }).ToList()
            };

            return atividades;
        }
    }
}