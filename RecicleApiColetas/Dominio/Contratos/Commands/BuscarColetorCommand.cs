using Core.Base;
using Dominio.Objetos;
using System;

namespace Dominio.Contratos.Commands
{
    public class BuscarColetorCommand : BaseCommand<Coletor>
    {
        public Guid Id { get; init; }
    }
}
