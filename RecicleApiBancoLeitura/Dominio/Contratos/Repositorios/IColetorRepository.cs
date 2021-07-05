using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Contratos.Repositorios
{
    public interface IColetorRepository : IBaseRepository<Coletor>, IQuery<Coletor, ColetorQuery>
    {
    }
}
