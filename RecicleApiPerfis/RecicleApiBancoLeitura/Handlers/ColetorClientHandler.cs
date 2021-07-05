using Core.Base;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class ColetorClientHandler : IBaseRequestHandler<BuscarColetorCommand, Coletor>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public ColetorClientHandler(ApiBancoLeituraInjector injector)
        {
            _injector = injector;
        }

        public async Task<Coletor> Handle(BuscarColetorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Coletor, BuscarColetorCommand>("coletor", request);
        }
    }
}
