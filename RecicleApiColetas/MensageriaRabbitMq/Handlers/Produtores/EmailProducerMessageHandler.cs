using Core.Base;
using Core.Eventos;
using Dominio.Contratos.Eventos;
using MensageriaRabbitMq.Setup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Produtores
{
    public class EmailProducerMessageHandler : IBaseEventHandler<EnviarEmailEvent>
    {
        private readonly MensageriaInjector _injector;

        public EmailProducerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }
        public async Task Handle(EnviarEmailEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            throw new NotImplementedException();
        }
    }
}
