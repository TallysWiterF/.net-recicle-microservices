using Core.Base;
using Dominio.Objetos;
using System;

namespace Dominio.Contratos.Commands
{
    public class BuscarItemCommand : BaseCommand<Item>
    {
        public Guid Id { get; init; }
    }
}
