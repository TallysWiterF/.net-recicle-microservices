using MensageriaRabbitMq.Setup.Contratos;
using System;

namespace MensageriaRabbitMq.Mensagens
{
    public class RemoverItemMessage : IMessageResponse
    {
        public Guid? IdDistribuidor { get; set; }
    }
}
