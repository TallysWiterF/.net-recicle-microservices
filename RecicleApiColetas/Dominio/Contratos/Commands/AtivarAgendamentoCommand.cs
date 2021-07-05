using Core.Base;
using System;

namespace Dominio.Contratos.Commands
{
    public class AtivarAgendamentoCommand : BaseCommand<bool>
    {
        public Guid Id { get; set; }

        public AtivarAgendamentoCommand(Guid id)
        {
            Id = id;
        }
    }
}
