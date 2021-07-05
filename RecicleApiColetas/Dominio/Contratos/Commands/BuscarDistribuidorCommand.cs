using Core.Base;
using Dominio.Objetos;
using System;

namespace Dominio.Contratos.Commands
{
    public class BuscarDistribuidorCommand : BaseCommand<Distribuidor>
    {
        public Guid Id { get; init; }
    }
}
