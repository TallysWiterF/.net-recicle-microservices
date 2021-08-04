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
    public class DistrbuidorClientHandler : IBaseRequestHandler<BuscarDistribuidorCommand, Distribuidor>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public DistrbuidorClientHandler(ApiBancoLeituraInjector injector)
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
