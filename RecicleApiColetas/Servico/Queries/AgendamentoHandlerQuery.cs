using Core.Base;
using Dominio.Contratos.Commands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class AgendamentoHandlerQuery : IBaseRequestHandler<AgendamentoQuery, IEnumerable<Agendamento>>
    {
        private readonly IMediatorCustom _mediator;

        public AgendamentoHandlerQuery(IMediatorCustom mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Agendamento>> Handle(AgendamentoQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _mediator.EnviarComandoAsync(new BuscarAgendamentoCommand(request));
        }
    }
}
