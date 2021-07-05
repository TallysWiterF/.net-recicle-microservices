using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class AtualizarItemCommand : BaseItemCommand<Item>
    {
        public Guid Id { get; set; }
    }
}
