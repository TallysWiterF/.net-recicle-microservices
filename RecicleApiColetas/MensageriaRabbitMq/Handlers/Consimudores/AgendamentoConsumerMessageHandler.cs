using AutoMapper;
using Dominio.Contratos.Commands;
using MensageriaRabbitMq.Contratos.Consumidores;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using MensageriaRabbitMq.Setup.Objetos;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Consimudores
{
    public class AgendamentoConsumerMessageHandler : IAgendamentoConsumerMessageHandler
    {
        private readonly MensageriaInjector _injector;
        private readonly IMapper _mapper;

        public AgendamentoConsumerMessageHandler(MensageriaInjector injector, IMapper mapper)
        {
            _injector = injector;
            _mapper = mapper;
        }

        public async Task Handle(ResponseHandler<RemoverAgendamentoMessage> response)
        {
            var command = _mapper.Map<RemoverAgendamentosCommand>(response.Dados);
            await _injector.MediatorCustom.EnviarComandoAsync(command);
        }

        public async Task Register()
        {
            await _injector.Rabbit.CreateQueue(Filas.REMOVER_AGENDAMENTO.ToString());
            await _injector.Rabbit.Consumer(this, Filas.REMOVER_AGENDAMENTO.ToString());
        }

        public async Task RegisterAll()
        {
            await Register();
        }
    }
}
