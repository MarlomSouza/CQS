using System;
using Aplicacao.Infraestrutura.Command;

namespace Aplicacao.Atividades.Command
{
    public class CriarAtividade : ICommand
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }
}