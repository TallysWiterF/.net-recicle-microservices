using Core.Base;
using Dominio.Entidades;
using Dominio.ValuesTypes;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Querys
{
    public class AgendamentoQuery : BaseCommand<IEnumerable<Agendamento>>
    {
        public Guid? Id { get; init; }
        public Guid? IdItem { get; init; }
        public Guid? IdColetor { get; init; }
        public int? HoraColeta { get; init; }
        public int? MinutoColeta { get; init; }
        public EnumDiasDaSemana? DiaDaSemanaColeta { get; init; }
    }
}
