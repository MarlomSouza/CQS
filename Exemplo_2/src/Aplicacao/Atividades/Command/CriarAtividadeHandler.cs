using System;
using Aplicacao.Infraestrutura.Command;
using Dominio.Entities;
using Dominio._Base;

namespace Aplicacao.Atividades.Command
{
    public class CriarAtividadeHandler : ICommandHandler<CriarAtividade>
    {
        private readonly IAtividadeService _atividadeService;

        public CriarAtividadeHandler(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        public void Execute(CriarAtividade command)
        {
            Enum.TryParse(command.Tipo, out TipoAtividade tipoAtividade);
            _atividadeService.AdicionarAtividade(command.Titulo, command.Descricao, tipoAtividade);
        }
    }
}