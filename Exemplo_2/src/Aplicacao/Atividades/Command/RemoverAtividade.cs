using Aplicacao.Infraestrutura.Command;

namespace Aplicacao.Atividades.Command
{
    public class RemoverAtividade : ICommand
    {
        public int IdAtividade { get; set; }
    }
}