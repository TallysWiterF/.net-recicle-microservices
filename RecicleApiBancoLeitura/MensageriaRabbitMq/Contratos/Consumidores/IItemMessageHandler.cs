﻿using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Contratos.Consumidores
{
    public interface IItemMessageHandler : IConsumer<ItemMessage>,
                                            IRegisters
    {
    }
}

