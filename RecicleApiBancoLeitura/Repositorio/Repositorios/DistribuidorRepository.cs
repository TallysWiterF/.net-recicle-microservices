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
    public class DistribuidorRepository : BaseRepository<Distribuidor>, IDistribuidorRepository
    {
        public DistribuidorRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public async Task<IEnumerable<Distribuidor>> BuscarAsync(DistribuidorQuery filter)
        {
            var idUserHasValue = filter.IdUser.HasValue;
            var idHasValue = filter.Id.HasValue;
            var filterBuilder = Builders<Distribuidor>.Filter.Where(x =>
                1 == 1
                && (!filter.Nome.HasValue() || x.Nome.ToLower().Contains(filter.Nome.ToLower()))
                && (!idUserHasValue || x.IdUser == filter.IdUser)
                && (!idHasValue || x.Id == filter.Id)
            );
            return await base.Buscarsync(filterBuilder);
        }

        protected override string GetNameCollection() => ContextMongo.DistribuidorCollectionName;
    }
}
