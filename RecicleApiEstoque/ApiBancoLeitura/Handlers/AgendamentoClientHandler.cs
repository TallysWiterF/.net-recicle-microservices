using Core.Base;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class ItemClientHandler : IBaseRequestHandler<BuscarItemCommand, IEnumerable<Item>>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public ItemClientHandler(ApiBancoLeituraInjector injector)
        {
            _injector = injector;
        }

        public async Task<IEnumerable<Item>> Handle(BuscarItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<IEnumerable<Item>, BuscarItemCommand>("item", request);
        }
    }
}
