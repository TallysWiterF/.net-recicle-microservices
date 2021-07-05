using Crosscuting.Funcoes;
using MensageriaRabbitMq.Setup.Contratos;
using MensageriaRabbitMq.Setup.Objetos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Setup
{
    public class Rabbit : IRabbit
    {
        private IConnection _connection;
        public Rabbit(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }

        public IModel CreateChannel() => _connection.CreateModel();

        public Task<InfoQueue> CreateQueue(string fila)
        {
            var canalEscolhido = CreateChannel();
            var queueCriada = new InfoQueue(canalEscolhido.QueueDeclare(queue: fila,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null));
            canalEscolhido.Dispose();
            return Task.FromResult(queueCriada);
        }

        public Task Producer(object request, string fila)
        {
            using var canalEscolhido = CreateChannel();
            canalEscolhido.BasicPublish(string.Empty, fila, null, Encoding.UTF8.GetBytes(JsonFunc.SerializeObject(request)));
            return Task.CompletedTask;
        }

        public Task Consumer<TResponse>(IConsumer<TResponse> consumidor, string fila, IModel channel = null)
        {
            var canalEscolhido = channel ?? CreateChannel();
            var consumer = new EventingBasicConsumer(canalEscolhido);
            consumer.Received += (sender, events) => HandlerRecebimento(consumidor, canalEscolhido, sender, events);
            canalEscolhido.BasicConsume(fila, false, consumer);
            return Task.CompletedTask;
        }

        #region Métodos Privados
        private IConnection CreateConnection(string connectionString)
        {
            var factory = new ConnectionFactory { Uri = new Uri(connectionString) };
            return factory.CreateConnection();
        }

        private void HandlerRecebimento<TResponse>(IConsumer<TResponse> consumidor, IModel canal,
                                        object value, BasicDeliverEventArgs events)
        {
            try
            {
                consumidor.Handle(new ResponseHandler<TResponse>(events)).Wait();
                canal.BasicAck(events.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                canal.BasicNack(events.DeliveryTag, true, true);
            }
        }
        #endregion
    }
}
