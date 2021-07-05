using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class AddItemCommand : BaseCommand<Item>
    {
        public Item Item { get; init; }
    }
}
