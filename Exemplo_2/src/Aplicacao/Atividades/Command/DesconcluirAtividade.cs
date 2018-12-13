using Aplicacao.Infraestrutura.Command;

namespace Aplicacao.Atividades.Command
{
    public class DesconcluirAtividade : ICommand
    {
        public int IdAtividade { get; set; }
    }
}