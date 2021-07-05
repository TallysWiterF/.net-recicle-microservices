using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contratos.Querys
{
    public interface IQuery<TReturn, TFilter> where TReturn : class where TFilter : class
    {
        Task<IEnumerable<TReturn>> BuscarAsync(TFilter filter);
    }
}
