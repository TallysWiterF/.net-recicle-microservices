using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IAgendamentoRepository : IBaseRepository<Agendamento>
    {
        Task<IEnumerable<Agendamento>> BuscarAsync(AgendamentoQuery filter);
    }
}
