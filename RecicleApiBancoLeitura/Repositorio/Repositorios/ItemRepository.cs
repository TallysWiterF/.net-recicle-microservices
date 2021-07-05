using Crosscuting.Extensoes;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using MongoDB.Driver;
using Repositorio.Contexto;
using Repositorio.Repositorios.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public async Task<IEnumerable<Item>> BuscarAsync(ItemQuery filter)
        {
            var idDistribuidorHasValue = filter.IdDistribuidor.HasValue;
            var idHasValue = filter.Id.HasValue;
            var filterBuilder = Builders<Item>.Filter.Where(x =>
                1 == 1 &&
                (!filter.Nome.HasValue() || x.Nome.ToLower().Contains(filter.Nome.ToLower()))
                && (!idDistribuidorHasValue || x.IdDistribuidor == filter.IdDistribuidor)
                && (!idHasValue || x.Id == filter.Id)
            );
            return await base.Buscarsync(filterBuilder);
        }

        protected override string GetNameCollection() => ContextMongo.ItemCollectionName;
    }
}

