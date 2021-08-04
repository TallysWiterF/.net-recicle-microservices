using Crosscuting.Extensoes;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;
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

        public Task<IEnumerable<Coletor>> BuscarAsync(ColetorQuery filter)
        {
            return Task.FromResult
                (
                    (Injector.Context.Coletor
                    .Where(x => (!filter.Nome.HasValue() || x.Nome.ToLower().Contains(filter.Nome.ToLower()))
                                && (!filter.Id.HasValue || x.Id == filter.Id.Value)
                                && (!filter.IdUser.HasValue || x.IdUser == filter.IdUser.Value)
                     ))
                     .AsEnumerable()
                 );
        }
    }
}
