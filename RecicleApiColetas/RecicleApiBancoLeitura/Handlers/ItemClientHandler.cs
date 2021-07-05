using Core.Base;
using Dominio.Contratos.Commands;
using Dominio.Objetos;
using RecicleApiBancoLeitura.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class ItemClientHandler : IBaseRequestHandler<BuscarItemCommand, Item>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public ItemClientHandler(ApiBancoLeituraInjector injector)
        {
            _injector = injector;
        }

        public async Task<Item> Handle(BuscarItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Item, BuscarItemCommand>("item", request);
        }
    }
}
