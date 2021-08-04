using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using Resiliencia.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class DistribuidorClientHandler : IBaseRequestHandler<BuscarDistribuidorCommand, Distribuidor>
    {
        private readonly ApiBancoLeituraInjector _injector;
        private readonly INotificador _notificador;
        private readonly IPollyFactory _polly;

        public DistribuidorClientHandler(ApiBancoLeituraInjector injector,
            INotificador notificador,
            IPollyFactory polly)
        {
            _injector = injector;
            _notificador = notificador;
            _polly = polly;
        }

        public async Task<Distribuidor> Handle(BuscarDistribuidorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Distribuidor, BuscarDistribuidorCommand>("distribuidor", request);
        }
    }
}
