using Crosscuting.Extensoes;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;
using Repositorio.Sincronizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public Task AtualizarEstoqueAsync(Item item, params string[] propriedades)
        {
            ValidarEntidade(item);
            if (propriedades is not null)
            {
                var entityEntry = Injector.Context.Entry(item.Estoque);
                foreach (var propriedade in propriedades)
                    entityEntry.Property(propriedade).IsModified = true;
            }
            else
                Injector.Context.Estoque.Update(item.Estoque);
            Injector.Sincronizador.AddEvento(new AtualizarSincronizacaoEvent<Item> { Entidade = item });
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Item>> BuscarAsync(ItemQuery query)
        {
            return Task.FromResult(Injector.Context.Item
                .Where(x => (!query.Id.HasValue || x.Id == query.Id.Value)
                            && (!query.IdDistribuidor.HasValue || x.IdDistribuidor == query.IdDistribuidor.Value)
                            && (!query.TipoMaterial.HasValue || x.TipoMaterial == query.TipoMaterial.Value)
                            && (!query.Nome.HasValue() || x.Nome.ToLower().Contains(query.Nome.ToLower())))
                .AsEnumerable());
        }
    }
}
