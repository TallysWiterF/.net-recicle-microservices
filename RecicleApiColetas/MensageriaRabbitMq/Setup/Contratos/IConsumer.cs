using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Setup.Contratos
{
    public interface IConsumer<TResponse> where TResponse : IMessageResponse
    {
        Task Handle(ResponseHandler<TResponse> response);
        Task Register();
    }
}
