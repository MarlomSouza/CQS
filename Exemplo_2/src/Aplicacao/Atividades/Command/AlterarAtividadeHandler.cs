using System;
using Aplicacao.Infraestrutura.Command;
using Dominio._Base;
using Dominio.Entities;

namespace Aplicacao.Atividades.Command
{
    public class AlterarAtividadeHandler : ICommandHandler<AlterarAtividade>
    {
        private readonly IAtividadeService _service;

        public AlterarAtividadeHandler(IAtividadeService service)
        {
            _service = service;
        }

        public void Execute(AlterarAtividade command)
        {
            Enum.TryParse(command.Tipo, out TipoAtividade tipoAtividade);
            _service.AlterarAtividade(command.Id, command.Titulo, command.Descricao, tipoAtividade);
        }
    }
}