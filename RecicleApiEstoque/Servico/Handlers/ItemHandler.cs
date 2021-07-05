using AutoMapper;
using Core.Base;
using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class ItemHandler : IBaseRequestHandler<AddItemCommand, Item>,
                                  IBaseRequestHandler<AtualizarItemCommand, Item>,
                                  IBaseRequestHandler<ReporItemEstoqueCommand, Estoque>,
                                  IBaseRequestHandler<DebitarItemEstoqueCommand, Estoque>,
                                  IBaseRequestHandler<RemoverItemCommand, bool>,
                                  IBaseRequestHandler<RemoverItensCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public ItemHandler(IItemRepository itemRepository, 
            INotificador notificador, 
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<Item> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Item>(request);
            if (!await ValidarAsync(entidade)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _itemRepository.AddAsync(entidade);
            await _itemRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Item> Handle(AtualizarItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var estoque = (await _itemRepository.BuscarAsync(x => x.Id == request.Id, nameof(Item.Estoque)))
                          .Select(x => x.Estoque).FirstOrDefault();
            var entidade = _mapper.Map<Item>(request);
            entidade.IniciarNovoEstoqe(estoque);
            entidade.Estoque.DefinirQuantidade(request.Quantidade);
            entidade.Estoque.DefinirTipoQuantidade(request.TipoQuantidade);
            entidade.Estoque.DefinirDataAtualizacao();
            entidade.Validar();
            if (!await ValidarAsync(entidade)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _itemRepository.AtualizarAsync(entidade);
            await _itemRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> Handle(RemoverItemCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            await _itemRepository.RemoverAsync(request.Id);
            return await _itemRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(RemoverItensCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            if (!request.DadosPreenchidos()) return false;
            await _itemRepository.RemoverRangeAsync(x => 
                    (!request.IdDistribuidor.HasValue || x.IdDistribuidor == request.IdDistribuidor.Value)
                    && (!request.Id.HasValue || x.Id == request.Id.Value));
            return await _itemRepository.UnitOfWork.CommitAsync();
        }

        public async Task<Estoque> Handle(ReporItemEstoqueCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = await _itemRepository.BuscarPorIdAsync(request.Id, nameof(Item.Estoque));
            if (entidade is null)
                return null;
            entidade.Estoque.ReporQuantidade(request.Quantidade);
            entidade.Validar();
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _itemRepository.AtualizarEstoqueAsync(entidade, nameof(Estoque.Quantidade));
            await _itemRepository.UnitOfWork.CommitAsync();
            return entidade.Estoque.DefinirDataAtualizacao();
        }

        public async Task<Estoque> Handle(DebitarItemEstoqueCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = await _itemRepository.BuscarPorIdAsync(request.Id, nameof(Item.Estoque));
            if(entidade is null)
                return null;
            entidade.Estoque.DebitarQuantidade(request.Quantidade);
            entidade.Validar();
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _itemRepository.AtualizarEstoqueAsync(entidade, nameof(Estoque.Quantidade));
            await _itemRepository.UnitOfWork.CommitAsync();
            return entidade.Estoque.DefinirDataAtualizacao();
        }

        #region Metodos Privados
        private async Task<bool> ValidarAsync(Item entidade)
        {
            var existe = await _itemRepository.ExisteAsync(x => (x.Id != entidade.Id)
                        && (x.Nome.ToLower().Equals(entidade.Nome.ToLower()))
                        && (x.IdDistribuidor == entidade.IdDistribuidor));
            if (existe)
                _notificador.Add("Item já cadastrado.", EnumTipoMensagem.Warning);
            return !existe;
        }
        #endregion
    }
}
