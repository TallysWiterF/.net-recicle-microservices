using Core.Base;
using System;

namespace Dominio.Contratos.Eventos.ColetorEventos
{
    public class ColetorRemovidoEvent : BaseEvent
    {
        public Guid Id { get; set; }

        public ColetorRemovidoEvent(Guid id)
        {
            Id = id;
        }
    }
}
