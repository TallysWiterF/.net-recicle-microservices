using Core.Base;
using Dominio.Contratos.Eventos.DistribuidorEventos;
using Dominio.Entidades;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using Repositorio.Sincronizacao;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Produtores
{
    public class DistribuidorProducerMessageHandler : IBaseEventHandler<AddSincronizacaoEvent<Distribuidor>>,
                                                      IBaseEventHandler<AtualizarSincronizacaoEvent<Distribuidor>>,
                                                      IBaseEventHandler<RemoverSincronizacaoEvent<Distribuidor>>,
                                                      IBaseEventHandler<DistribuidorRemovidoEvent>
    {
        private readonly MensageriaInjector _injector;

        public DistribuidorProducerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(AddSincronizacaoEvent<Distribuidor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.DISTRIBUIDOR_LEITURA.ToString());
        }

        public async Task Handle(AtualizarSincronizacaoEvent<Distribuidor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.DISTRIBUIDOR_LEITURA.ToString());
        }

        public async Task Handle(RemoverSincronizacaoEvent<Distribuidor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.DISTRIBUIDOR_LEITURA.ToString());
        }

        public async Task Handle(DistribuidorRemovidoEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(new RemoverItemMessage(notification.Id), Filas.REMOVER_ITEM.ToString());
        }
    }
}

