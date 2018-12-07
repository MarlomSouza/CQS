using System;
using Dominio.Exceptions;

namespace Dominio.Entities
{
    public class Atividade : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public TipoAtividade Tipo { get; private set; }
        public bool Concluida { get; private set; }


        public Atividade(string titulo, string descricao, TipoAtividade tipo, DateTime dataCriacao)
        {
            DomainException.Quando(string.IsNullOrWhiteSpace(titulo),
                            "Não é permitido criar atividade com titulo inválido");
            DomainException.Quando(dataCriacao.Date.DayOfWeek == DayOfWeek.Friday && dataCriacao.Hour >= 13,
                            "Não pode criar atividade do tipo manutenção urgente após as 13h da sexta-feira");

            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
        }

        private Atividade()
        {
        }

        public void Alterar(string titulo, string descricao, TipoAtividade tipo, DateTime data)
        {
            var ehTipoManutencaoUrgente = tipo == TipoAtividade.ManutencaoUrgente;
            var horarioInvalido = data.Date.DayOfWeek == DayOfWeek.Friday && data.Hour >= 13;
            DomainException.Quando(ehTipoManutencaoUrgente && horarioInvalido,
                            "Não pode alterar atividade para manutenção urgente após as 13h da sexta-feira");

            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
        }

        public void Concluir()
        {
            const int quantidadeMinimaDeCaracter = 50;
            DomainException.Quando(Descricao.Length < quantidadeMinimaDeCaracter
            && (Tipo == TipoAtividade.ManutencaoUrgente || Tipo == TipoAtividade.Atendimento),
                             "Quantidade de caracteres inferior a 50");

            Concluida = true;
        }

        public void Desconcluir() => Concluida = false;

        public bool PodeExcluir()
        {
            DomainException.Quando(Tipo == TipoAtividade.ManutencaoUrgente,
                             "Não pode excluir atividade que seja do tipo manutação urgente");
            return true;
        }
    }

}