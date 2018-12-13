using Aplicacao.Infraestrutura.Command;
using Dominio._Base;

namespace Aplicacao.Atividades.Command
{
    public class RemoverAtividadeHandler : ICommandHandler<RemoverAtividade>
    {
        private readonly IAtividadeService _service;
        public RemoverAtividadeHandler(IAtividadeService service)
        {
            _service = service;
        }

        public void Execute(RemoverAtividade command)
        {
            _service.RemoverAtividade(command.IdAtividade);
        }
    }
}