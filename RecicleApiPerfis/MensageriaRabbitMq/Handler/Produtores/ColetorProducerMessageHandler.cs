using Core.Base;
using Dominio.Contratos.Eventos.ColetorEventos;
using Dominio.Entidades;
using MensageriaRabbitMq.Mensagens;
using MensageriaRabbitMq.Setup;
using Repositorio.Sincronizacao;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Produtores
{
    public class ColetorProducerMessageHandler : IBaseEventHandler<AddSincronizacaoEvent<Coletor>>,
                                                 IBaseEventHandler<AtualizarSincronizacaoEvent<Coletor>>,
                                                 IBaseEventHandler<RemoverSincronizacaoEvent<Coletor>>,
                                                 IBaseEventHandler<ColetorRemovidoEvent>
    {
        private readonly MensageriaInjector _injector;

        public ColetorProducerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(AddSincronizacaoEvent<Coletor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.COLETOR_LEITURA.ToString());
        }

        public async Task Handle(AtualizarSincronizacaoEvent<Coletor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.COLETOR_LEITURA.ToString());
        }

        public async Task Handle(RemoverSincronizacaoEvent<Coletor> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.COLETOR_LEITURA.ToString());
        }

        public async Task Handle(ColetorRemovidoEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(new RemoverAgendamentoMessage(idColetor: notification.Id), Filas.REMOVER_AGENDAMENTO.ToString());
        }
    }
}

