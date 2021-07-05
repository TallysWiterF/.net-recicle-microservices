using Core.Base;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class ItemHandler : IBaseRequestHandler<AddItemCommand, Item>,
                                      IBaseRequestHandler<AtualizarItemCommand, Item>,
                                      IBaseRequestHandler<RemoverItemCommand, bool>
    {
        private readonly HandlerInjector _injector;
        private readonly IItemRepository _ItemRepository;

        public ItemHandler(IItemRepository ItemRepository, HandlerInjector injector)
        {
            _ItemRepository = ItemRepository;
            _injector = injector;
        }

        public async Task<Item> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            await _ItemRepository.AddAsync(request.Item);
            return request.Item;
        }

        public async Task<Item> Handle(AtualizarItemCommand request, CancellationToken cancellationToken)
        {
            await _ItemRepository.AtualizarAsync(request.Item);
            return request.Item;
        }

        public async Task<bool> Handle(RemoverItemCommand request, CancellationToken cancellationToken)
        {
            await _ItemRepository.RemoverAsync(request.Id);
            return true;
        }
    }
}
