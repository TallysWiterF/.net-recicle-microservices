using Core.Base;
using Dominio.Contratos.Commands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using RecicleApiBancoLeitura.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Handlers
{
    public class AgendamentoClientHandler : IBaseRequestHandler<BuscarAgendamentoCommand, IEnumerable<Agendamento>>
    {
        private readonly ApiBancoLeituraInjector _injector;

        public AgendamentoClientHandler(ApiBancoLeituraInjector injector)
        {
            _injector = injector;
        }

        public async Task<IEnumerable<Agendamento>> Handle(BuscarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _injector.Client.GetAsync<IEnumerable<Agendamento>, BuscarAgendamentoCommand>("agendamento", request);
        }
    }
}
