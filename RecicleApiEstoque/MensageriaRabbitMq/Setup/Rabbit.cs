using Crosscuting.Funcoes;
using MensageriaRabbitMq.Setup.Contratos;
using MensageriaRabbitMq.Setup.Objetos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
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

        public Task<InfoQueue> CreateQueue(string fila, Dictionary<string, object> args = null, IModel canal = null)
        {
            var canalEscolhido = canal ?? CreateChannel();
            var queueCriada = new InfoQueue(canalEscolhido.QueueDeclare(queue: fila,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: args));
            if(canal is null)
                canalEscolhido.Dispose();
            return Task.FromResult(queueCriada);
        }

        public Task Producer(object request, string fila)
        {
            using var canalEscolhido = CreateChannel();
            canalEscolhido.BasicPublish(string.Empty, fila, null, Encoding.UTF8.GetBytes(JsonFunc.SerializeObject(request)));
            return Task.CompletedTask;
        }

        public Task Consumer<TResponse>(IConsumer<TResponse> consumidor, string fila, IModel channel = null) where TResponse : IMessageResponse
        {
            var canalEscolhido = channel ?? CreateChannel();
            canalEscolhido.BasicQos(0, 5, false);
            CriarSetupDeadLetter(canalEscolhido);
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
                                        object value, BasicDeliverEventArgs events) where TResponse : IMessageResponse
        {
            try
            {
                consumidor.Handle(new ResponseHandler<TResponse>(events));
                canal.BasicAck(events.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                canal.BasicNack(events.DeliveryTag, true, false);
            }
        }

        private void CriarSetupDeadLetter(IModel canal)
        {
            var argumentos = new Dictionary<string, object>
            {
                {"x-dead-letter-exchange", Filas.DEAD_LETTER_ESTOQUE.ToString() }
            };
            canal.ExchangeDeclare(Filas.DEAD_LETTER_ESTOQUE.ToString(), ExchangeType.Fanout);
            CreateQueue(Filas.DEAD_LETTER_ESTOQUE.ToString(), argumentos, canal).Wait();
            canal.QueueBind(Filas.DEAD_LETTER_ESTOQUE.ToString(), Filas.DEAD_LETTER_ESTOQUE.ToString(), string.Empty);
        }
        #endregion
    }
}
