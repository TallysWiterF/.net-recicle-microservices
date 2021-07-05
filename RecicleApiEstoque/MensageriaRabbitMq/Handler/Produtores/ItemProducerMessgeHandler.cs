using Core.Base;
using Dominio.Entidades;
using MensageriaRabbitMq.Setup;
using Repositorio.Sincronizacao;
using System.Threading;
using System.Threading.Tasks;

namespace MensageriaRabbitMq.Handler.Produtores
{
    public class ItemProducerMessgeHandler : IBaseEventHandler<AddSincronizacaoEvent<Item>>,
                                             IBaseEventHandler<AtualizarSincronizacaoEvent<Item>>,
                                             IBaseEventHandler<RemoverSincronizacaoEvent<Item>>
    {
        private readonly MensageriaInjector _injector;

        public ItemProducerMessgeHandler(MensageriaInjector injector)
        {
            _injector = injector;
        }

        public async Task Handle(AddSincronizacaoEvent<Item> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            notification.Entidade.Estoque.DefinirItem(null);
            await _injector.Rabbit.Producer(notification, Filas.ESTOQUE_LEITURA.ToString());
        }

        public async Task Handle(AtualizarSincronizacaoEvent<Item> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            notification.Entidade.Estoque.DefinirItem(null);
            await _injector.Rabbit.Producer(notification, Filas.ESTOQUE_LEITURA.ToString());
        }

        public async Task Handle(RemoverSincronizacaoEvent<Item> notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            await _injector.Rabbit.Producer(notification, Filas.ESTOQUE_LEITURA.ToString());
        }
    }
}
