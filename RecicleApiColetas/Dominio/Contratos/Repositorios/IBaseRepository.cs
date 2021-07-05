using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IBaseRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddAsync(T entidade);
        Task RemoverAsync(Guid id);
        Task RemoverRangeAsync(Expression<Func<T, bool>> filter);
        Task AtualizarAsync(T entidade);
        Task AtualizarPropsAsync(T entidade, params string[] propriedades);
        Task<IQueryable<T>> BuscarAsync();
        Task<IQueryable<T>> BuscarAsync(Expression<Func<T, bool>> filter, params string[] includes);
        Task<T> BuscarPorIdAsync(Guid id, params string[] includes);
        Task<bool> ExisteAsync(Expression<Func<T, bool>> filter);
    }
}
