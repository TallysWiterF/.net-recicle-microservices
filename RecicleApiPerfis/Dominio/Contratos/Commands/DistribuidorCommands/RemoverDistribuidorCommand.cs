using Dominio.Contratos.Commands.Base;
using System;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class RemoverDistribuidorCommand : RemoverCommand
    {
        public RemoverDistribuidorCommand()
        {

        }
        public RemoverDistribuidorCommand(Guid id)
        {
            Id = id;
        }
    }
}
