using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands;
using Dominio.Objetos;
using RecicleApiBancoLeitura.Setup;
using Resiliencia.Objetos;
using Resiliencia.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class ItemClientHandler : IBaseRequestHandler<BuscarItemCommand, Item>
    {
        private readonly ApiBancoLeituraInjector _injector;
        private readonly IPollyFactory _polly;

        public ItemClientHandler(ApiBancoLeituraInjector injector,
            IPollyFactory polly)
        {
            _injector = injector;
            _polly = polly;
        }

        public async Task<Item> Handle(BuscarItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Item, BuscarItemCommand>("item", request);
        }
    }
}
