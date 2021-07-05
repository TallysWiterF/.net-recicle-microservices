using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class BuscarItemCommand : BaseCommand<IEnumerable<Item>>
    {
        public ItemQuery Query { get; set; }

        public BuscarItemCommand(ItemQuery query)
        {
            Query = query;
        }
    }
}
