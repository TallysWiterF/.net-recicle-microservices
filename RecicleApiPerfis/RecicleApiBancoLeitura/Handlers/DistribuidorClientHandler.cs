using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class DistribuidorClientHandler : IBaseRequestHandler<BuscarDistribuidorCommand, Distribuidor>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public DistribuidorClientHandler(ApiBancoLeituraInjector injector)
        {
            _injector = injector;
        }

        public async Task<Distribuidor> Handle(BuscarDistribuidorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Distribuidor, BuscarDistribuidorCommand>("distribuidor", request);
        }
    }
}
