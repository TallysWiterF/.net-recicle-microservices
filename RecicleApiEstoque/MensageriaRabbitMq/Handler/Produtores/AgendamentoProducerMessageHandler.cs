using Core.Base;
using Dominio.Contratos.Eventos;
using MensageriaRabbitMq.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handler.Produtores
{
    public class AgendamentoProducerMessageHandler : IBaseEventHandler<RemoverAgendamentoEvent>
    {
        private readonly MensageriaInjector _injector;

        public AgendamentoProducerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(RemoverAgendamentoEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.REMOVER_AGENDAMENTO.ToString());
        }
    }
}
