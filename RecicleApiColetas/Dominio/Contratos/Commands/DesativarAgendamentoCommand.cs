using Core.Base;
using System;

namespace Dominio.Contratos.Commands
{
    public class DesativarAgendamentoCommand : BaseCommand<bool>
    {
        public Guid Id { get; set; }

        public DesativarAgendamentoCommand(Guid id)
        {
            Id = id;
        }
    }
}
