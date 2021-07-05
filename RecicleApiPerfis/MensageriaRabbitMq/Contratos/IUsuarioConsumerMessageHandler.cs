using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup.Contratos;

namespace MensageriaRabbitMq.Contratos
{
    public interface IUsuarioConsumerMessageHandler : IConsumer<UsuarioRemovidoMessage>, IRegisters
    {
    }
}
