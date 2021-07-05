using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class ItemQueryHandler : IBaseRequestHandler<ItemQuery, IEnumerable<Item>>
    {
        private readonly IItemRepository _ItemRepository;

        public ItemQueryHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<IEnumerable<Item>> Handle(ItemQuery request, CancellationToken cancellationToken)
        {
            return await _ItemRepository.BuscarAsync(request);
        }
    }
}
