using Core.Base;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup;
using Repositorio.Sincronizacao;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handlers.Produtores
{
    public class AgendamentoProducerMessageHandler : IBaseEventHandler<AddSincronizacaoEvent<Agendamento>>,
                                                     IBaseEventHandler<AtualizarSincronizacaoEvent<Agendamento>>,
                                                     IBaseEventHandler<RemoverSincronizacaoEvent<Agendamento>>
    {
        private readonly MensageriaInjector _injector;

        public AgendamentoProducerMessageHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(AddSincronizacaoEvent<Agendamento> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.AGENDAMENTO_LEITURA.ToString());
        }

        public async Task Handle(AtualizarSincronizacaoEvent<Agendamento> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.AGENDAMENTO_LEITURA.ToString());
        }

        public async Task Handle(RemoverSincronizacaoEvent<Agendamento> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.AGENDAMENTO_LEITURA.ToString());
        }
    }
}
