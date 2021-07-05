using MensageriaRabbitMq.Setup.Objetos;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Setup.Contratos
{
    public interface IRabbit
    {
        IModel CreateChannel();
        Task<InfoQueue> CreateQueue(string fila);
        Task Producer(object request, string fila);
        Task Consumer<TResponse>(IConsumer<TResponse> consumidor, string fila, IModel channel = null);
    }
}
