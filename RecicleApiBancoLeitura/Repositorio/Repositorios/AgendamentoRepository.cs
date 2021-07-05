using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Contexto;
using Repositorio.Repositorios.Base;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        protected override string GetNameCollection() => ContextMongo.AgendamentoCollectionName;
    }
}
