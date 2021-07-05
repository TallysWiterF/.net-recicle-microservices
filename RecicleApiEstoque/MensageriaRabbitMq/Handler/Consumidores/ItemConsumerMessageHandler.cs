using AutoMapper;
using Dominio.Contratos.Commands.ItemCommands;
using MensageriaRabbitMq.Contratos.Consumidores;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Consimudores
{
    public class ItemConsumerMessageHandler : IItemConsumerMessageHandler
    {
        private readonly MensageriaInjector _injector;
        private readonly IMapper _mapper;

        public ItemConsumerMessageHandler(MensageriaInjector injector,
            IMapper mapper)
        {
            _injector = injector;
            _mapper = mapper;
        }

        public async Task Register()
        {
            await _injector.Rabbit.CreateQueue(Filas.REMOVER_ITEM.ToString());
            await _injector.Rabbit.Consumer(this, Filas.REMOVER_ITEM.ToString());
        }

        public async Task Handle(ResponseHandler<RemoverItemMessage> response)
        {
            var command = _mapper.Map<RemoverItensCommand>(response);
            await _injector.MediatorCustom.EnviarComandoAsync(command);
        }

        public async Task RegisterAll()
        {
            await Register();
        }
    }
}
