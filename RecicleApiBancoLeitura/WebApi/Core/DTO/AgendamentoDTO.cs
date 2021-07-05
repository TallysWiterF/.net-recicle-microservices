using Dominio.ValuesTypes;
using System;

namespace WebApi.Core.DTO
{
    public class AgendamentoDTO : BaseDTO
    {
        public Guid IdItem { get; private set; }
        public Guid IdColetor { get; private set; }
        public int HoraColeta { get; private set; }
        public int MinutoColeta { get; private set; }
        public EnumDiasDaSemana DiaDaSemanaColeta { get; private set; }
        public bool Ativo { get; private set; }
    }
}
