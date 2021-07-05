using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IDistribuidorRepository : IBaseRepository<Distribuidor>
    {
        Task<IQueryable<Endereco>> BuscarEnderecoAsync(Expression<Func<Endereco, bool>> filter = null);
        Task AddAsync(Distribuidor entidade, bool novoEndereco = true);
        Task AtualizarAsync(Distribuidor entidade, bool novoEndereco = true);
        Task<IEnumerable<Distribuidor>> BuscarAsync(DistribuidorQuery filter);
    }
}
