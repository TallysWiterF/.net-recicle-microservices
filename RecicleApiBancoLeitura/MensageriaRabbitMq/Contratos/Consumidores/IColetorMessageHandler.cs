using Dominio.Contratos.Commands.ColetorCommands;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Contratos.Consumidores
{
    public interface IColetorMessageHandler : IConsumer<ColetorMessage>, 
                                                IRegisters
    {
    }
}
