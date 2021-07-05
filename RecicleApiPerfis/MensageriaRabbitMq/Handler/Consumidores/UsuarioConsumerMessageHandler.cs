using MensageriaRabbitMq.Contratos;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handler.Consumidores
{
    public class UsuarioConsumerMessageHandler : IUsuarioConsumerMessageHandler
    {
        private readonly MensageriaInjector _injector;

        public UsuarioConsumerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }
        public async Task Handle(ResponseHandler<UsuarioRemovidoMessage> response)
        {
            await _injector.MediatorCustom.EnviarComandoAsync(response.Dados.CriarCommandRemocaoEspecifica());
        }

        public async Task Register()
        {
            await _injector.Rabbit.CreateQueue(Filas.USUARIO_REMOVIDO.ToString());
            await _injector.Rabbit.Consumer(this, Filas.USUARIO_REMOVIDO.ToString());
        }

        public async Task RegisterAll()
        {
           await Register();
        }
    }
}
