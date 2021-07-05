using Core.Base;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class ColetorHandlerQuery : IBaseRequestHandler<ColetorQuery, Coletor>
    {
        private readonly IMediatorCustom _mediator;

        public ColetorHandlerQuery(IMediatorCustom mediator)
        {
            _mediator = mediator;
        }

        public async Task<Coletor> Handle(ColetorQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _mediator.EnviarComandoAsync(new BuscarColetorCommand(request));
        }
    }
}
