using Core.Base;
using Dominio.Entidades;
using Dominio.ValuesTypes;
using System;

namespace Dominio.Contratos.Commands
{
    public class BaseAgendamentoCommand : BaseCommand<Agendamento>
    {
        public Guid IdItem { get; init; }
        public Guid IdColetor { get; init; }
        public int HoraColeta { get; init; }
        public int MinutoColeta { get; init; }
        public EnumDiasDaSemana DiaDaSemanaColeta { get; init; }
    }
}
