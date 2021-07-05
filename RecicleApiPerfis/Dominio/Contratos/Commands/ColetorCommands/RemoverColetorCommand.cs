using Dominio.Contratos.Commands.Base;
using System;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class RemoverColetorCommand : RemoverCommand
    {
        public RemoverColetorCommand()
        {

        }
        public RemoverColetorCommand(Guid id)
        {
            Id = id;
        }
    }
}
