using MensageriaRabbitMq.Contratos.Consumidores;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers
{
    public class ItemConsumerMessageHandler : IItemMessageHandler
    {
        private readonly MensageriaInjector _injector;

        public ItemConsumerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(ResponseHandler<ItemMessage> response)
        {
            if (response.Dados.Tipo == EnumTipoSincronizacaoMessage.REMOVER)
                await _injector.MediatorCustom.EnviarComandoAsync(response.Dados.CriarCommandRemover());
            else
                await _injector.MediatorCustom.EnviarComandoAsync(response.Dados.CriarCommandEspecifico());
        }


        public async Task Register()
        {
            await _injector.Rabbit.CreateQueue(Filas.ESTOQUE_LEITURA.ToString());
            await _injector.Rabbit.Consumer(this, Filas.ESTOQUE_LEITURA.ToString());
        }
        public async Task RegisterAll()
        {
            await Register();
        }
    }
}
