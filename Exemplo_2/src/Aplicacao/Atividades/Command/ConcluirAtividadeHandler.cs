using Aplicacao.Infraestrutura.Command;
using Dominio._Base;

namespace Aplicacao.Atividades.Command
{
    public class ConcluirAtividadeHandler : ICommandHandler<ConcluirAtividade>
    {
        private readonly IAtividadeService _atividadeService;

        public ConcluirAtividadeHandler(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        public void Execute(ConcluirAtividade command)
        {
            _atividadeService.ConcluirAtividade(command.IdAtividade);
        }
    }
}