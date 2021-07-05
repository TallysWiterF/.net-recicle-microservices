using Core.Base;
using System;

namespace Dominio.Contratos.Eventos
{
    public class RemoverAgendamentoEvent : BaseEvent
    {
        public RemoverAgendamentoEvent(Guid? idDistribuidor, Guid? idColetor)
        {
            IdDistribuidor = idDistribuidor;
            IdColetor = idColetor;
        }

        public Guid? IdDistribuidor { get; set; }
        public Guid? IdColetor { get; set; }
    }
}
