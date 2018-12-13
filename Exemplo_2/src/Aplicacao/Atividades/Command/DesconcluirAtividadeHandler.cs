using Aplicacao.Infraestrutura.Command;
using Dominio._Base;

namespace Aplicacao.Atividades.Command
{
    public class DesconcluirAtividadeHandler : ICommandHandler<DesconcluirAtividade>
    {
        private readonly IAtividadeService _service;
        public DesconcluirAtividadeHandler(IAtividadeService service)
        {
            _service = service;
        }

        public void Execute(DesconcluirAtividade command)
        {
            _service.DesconcluirAtividade(command.IdAtividade);
        }
    }
}