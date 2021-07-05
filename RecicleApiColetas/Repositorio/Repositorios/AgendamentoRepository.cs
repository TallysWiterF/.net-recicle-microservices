using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public Task<IEnumerable<Agendamento>> BuscarAsync(AgendamentoQuery filter)
        {
            return Task.FromResult(Injector.Context.Agendamento
                       .Where(x => (!filter.Id.HasValue || x.Id == filter.Id.Value)
                       && (!filter.IdItem.HasValue || x.IdItem == filter.IdItem.Value)
                       && (!filter.IdColetor.HasValue || x.IdColetor == filter.IdColetor.Value)
                       && (!filter.HoraColeta.HasValue || x.HoraColeta == filter.HoraColeta.Value)
                       && (!filter.MinutoColeta.HasValue || x.MinutoColeta == filter.MinutoColeta.Value)
                       && (!filter.DiaDaSemanaColeta.HasValue || x.DiaDaSemanaColeta == filter.DiaDaSemanaColeta.Value))
                       .AsEnumerable());
        }
    }
}
