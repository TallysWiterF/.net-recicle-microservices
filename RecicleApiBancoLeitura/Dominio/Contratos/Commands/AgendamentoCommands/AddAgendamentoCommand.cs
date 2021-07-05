using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.AgendamentoCommands
{
    public class AddAgendamentoCommand : BaseCommand<Agendamento>
    {
        public Agendamento Agendamento { get; init; }
    }
}
