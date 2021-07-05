using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Contratos.Repositorios
{
    public interface IDistribuidorRepository : IBaseRepository<Distribuidor>, IQuery<Distribuidor, DistribuidorQuery>
    {
    }
}
