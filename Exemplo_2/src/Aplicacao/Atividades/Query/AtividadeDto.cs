namespace Aplicacao.Atividades.Query
{
    public class AtividadeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool Concluida { get; set; }
    }
}