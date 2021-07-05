using Dominio.ValuesTypes;
using System;

namespace Dominio.Entidades
{
    public class Agendamento : Entity
    {
        public Guid IdItem { get; init; }
        public Guid IdColetor { get; init; }
        public int HoraColeta { get; init; }
        public int MinutoColeta { get; init; }
        public EnumDiasDaSemana DiaDaSemanaColeta { get; init; }
        public bool Ativo { get; init; }
    }
}
