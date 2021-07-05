using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IColetorRepository : IBaseRepository<Coletor>
    {
        Task<IEnumerable<Coletor>> BuscarAsync(ColetorQuery filter);
    }
}
