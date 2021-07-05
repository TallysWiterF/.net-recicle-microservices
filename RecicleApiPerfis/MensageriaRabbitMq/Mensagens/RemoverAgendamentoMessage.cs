using MensageriaRabbitMq.Setup.Contratos;
using System;

namespace MensageriaRabbitMq.Mensagens
{
    public class RemoverAgendamentoMessage : IMessageResponse
    {
        public RemoverAgendamentoMessage(Guid? idItem = null, Guid? idColetor = null)
        {
            IdItem = idItem;
            IdColetor = idColetor;
        }

        public Guid? IdItem { get; set; }
        public Guid? IdColetor { get; set; }
    }
}
