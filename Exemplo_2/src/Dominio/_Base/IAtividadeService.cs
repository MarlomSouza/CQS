using System.Collections.Generic;
using Dominio.Entities;

namespace Dominio._Base
{
    public interface IAtividadeService
    {
        void AdicionarAtividade(string titulo, string descricao, TipoAtividade tipo);
        void AlterarAtividade(int id, string titulo, string descricao, TipoAtividade tipo);
        void ConcluirAtividade(int id);
        void DesconcluirAtividade(int id);
        IEnumerable<Atividade> ListaAtividadeEmAberto();
        IEnumerable<Atividade> ListaAtividadeConcluida();
        void RemoverAtividade(int id);
    }
}