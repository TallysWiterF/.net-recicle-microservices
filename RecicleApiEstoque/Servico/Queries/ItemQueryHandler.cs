using Core.Base;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class ItemHandlerQuery : IBaseRequestHandler<ItemQuery, IEnumerable<Item>>
    {
        private readonly IMediatorCustom _mediator;

        public ItemHandlerQuery(IMediatorCustom mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Item>> Handle(ItemQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            return await _mediator.EnviarComandoAsync(new BuscarItemCommand(request));
        }
    }
}
