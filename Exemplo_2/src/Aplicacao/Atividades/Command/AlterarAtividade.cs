using Aplicacao.Infraestrutura.Command;

namespace Aplicacao.Atividades.Command
{
    public class AlterarAtividade : ICommand
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }
}