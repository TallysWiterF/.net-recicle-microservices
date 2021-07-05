using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class DistribuidorHandlerQuery : IBaseRequestHandler<DistribuidorQuery, Distribuidor>
    {
        private readonly IMediatorCustom _mediator;

        public DistribuidorHandlerQuery(IMediatorCustom mediator)
        {
            _mediator = mediator;
        }

        public async Task<Distribuidor> Handle(DistribuidorQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _mediator.EnviarComandoAsync(new BuscarDistribuidorCommand(request));
        }
    }
}
