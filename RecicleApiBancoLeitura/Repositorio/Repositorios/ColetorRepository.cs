using Crosscuting.Extensoes;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using MongoDB.Driver;
using Repositorio.Contexto;
using Repositorio.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ColetorRepository : BaseRepository<Coletor>, IColetorRepository
    {
        public ColetorRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public async Task<IEnumerable<Coletor>> BuscarAsync(ColetorQuery filter)
        {
            var idUserHasValue = filter.IdUser.HasValue;
            var idHasValue = filter.Id.HasValue;
            var filterBuilder = Builders<Coletor>.Filter.Where(x =>
                1 == 1 &&
                (!filter.Email.HasValue() || x.Email == filter.Email)
                && (!filter.Nome.HasValue() || x.Nome.ToLower().Contains(filter.Nome.ToLower()))
                && (!idUserHasValue || x.IdUser == filter.IdUser)
                && (!idHasValue || x.Id == filter.Id)
            );
            return await base.Buscarsync(filterBuilder);
        }

        protected override string GetNameCollection() => ContextMongo.ColetorCollectionName;
    }
}
