using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Contratos.Commands
{
    public class BuscarAgendamentoCommand : BaseCommand<IEnumerable<Agendamento>>
    {
        public AgendamentoQuery Query { get; set; }

        public BuscarAgendamentoCommand(AgendamentoQuery query)
        {
            Query = query;
        }
    }
}
