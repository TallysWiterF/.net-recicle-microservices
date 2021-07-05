using Aplicacao.Eventos;
using Core.Base;
using MensageriaRabbitMq.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handler.Produtores
{
    public class UsuarioMessageProducer : IBaseEventHandler<UsuarioRemovidoEvent>
    {
        private readonly MensageriaInjector _injector;

        public UsuarioMessageProducer(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(UsuarioRemovidoEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.USUARIO_REMOVIDO.ToString());
        }
    }
}
