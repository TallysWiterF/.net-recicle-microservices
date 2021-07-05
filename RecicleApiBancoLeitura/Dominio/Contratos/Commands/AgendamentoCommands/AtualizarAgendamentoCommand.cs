using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.AgendamentoCommands
{
    public class AtualizarAgendamentoCommand : BaseCommand<Agendamento>
    {
        public Agendamento Agendamento { get; init; }
    }
}
