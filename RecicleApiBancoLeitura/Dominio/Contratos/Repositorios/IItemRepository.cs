using Dominio.Contratos.Querys;
using Dominio.Entidades;

namespace Dominio.Contratos.Repositorios
{
    public interface IItemRepository : IBaseRepository<Item>, IQuery<Item, ItemQuery>
    {
    }
}
