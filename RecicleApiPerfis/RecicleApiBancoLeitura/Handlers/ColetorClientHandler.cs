using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using Resiliencia.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class ColetorClientHandler : IBaseRequestHandler<BuscarColetorCommand, Coletor>
    {
        private readonly ApiBancoLeituraInjector _injector;
        private readonly INotificador _notificador;
        private readonly IPollyFactory _polly;

        public ColetorClientHandler(ApiBancoLeituraInjector injector,
            INotificador notificador, 
            IPollyFactory polly)
        {
            _injector = injector;
            _notificador = notificador;
            _polly = polly;
        }

        public async Task<Coletor> Handle(BuscarColetorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<Coletor, BuscarColetorCommand>("coletor", request);
        }
    }
}
