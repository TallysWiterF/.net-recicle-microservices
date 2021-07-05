using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class AtualizarDistribuidorCommand : BaseDistribuidorCommand<Distribuidor>
    {
        public Guid Id { get; set; }
    }
}
