using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task AddAsync(T entidade);
        Task RemoverAsync(Guid id);
        Task AtualizarAsync(T entidade);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> filter);
        Task<T> BuscarPorIdAsync(Guid id);
    }

    public interface IBaseRepository<T, TFilter> : IBaseRepository<T> where T : Entity
    {
        Task<T> BuscarAsync(TFilter filter);

    }
}
