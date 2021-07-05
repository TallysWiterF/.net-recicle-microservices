using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<IEnumerable<Item>> BuscarAsync(ItemQuery query);
        Task AtualizarEstoqueAsync(Item item, params string[] propriedades);
    }
}
