using System.Collections.Generic;
using Aplicacao.Infraestrutura.Query;

namespace Aplicacao.Atividades.Query
{
    public class ListarAtividades : IQuery<AtividadesDto>
    {
        public bool Concluida { get; set; }
    }
}