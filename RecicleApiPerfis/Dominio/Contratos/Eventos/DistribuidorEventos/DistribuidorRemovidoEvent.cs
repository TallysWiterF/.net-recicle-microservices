using Core.Base;
using System;

namespace Dominio.Contratos.Eventos.DistribuidorEventos
{
    public class DistribuidorRemovidoEvent : BaseEvent
    {
        public Guid Id { get; set; }

        public DistribuidorRemovidoEvent(Guid id)
        {
            Id = id;
        }
    }
}
