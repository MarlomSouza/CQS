using System.Linq;
using Aplicacao.Infraestrutura.Query;
using Dominio._Base;
using Dominio.Entities;

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
            var atividades = new AtividadesDto();

            if (query.Concluida)
                atividades.Atividades = _service.ListaAtividadeConcluida().Select(Mapear).ToList();
            else
                atividades.Atividades = _service.ListaAtividadeEmAberto().Select(Mapear).ToList();

            return atividades;
        }

        private AtividadeDto Mapear(Atividade atividade)
        {
            return new AtividadeDto
            {
                Titulo = atividade.Titulo,
                Descricao = atividade.Descricao,
                Tipo = atividade.Tipo.ToString(),
                Concluida = atividade.Concluida
            };
        }
    }
}