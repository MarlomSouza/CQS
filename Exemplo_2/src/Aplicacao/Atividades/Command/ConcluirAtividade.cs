using Aplicacao.Infraestrutura.Command;

namespace Aplicacao.Atividades.Command
{
    public class ConcluirAtividade : ICommand
    {
        public int IdAtividade { get; set; }
    }
}