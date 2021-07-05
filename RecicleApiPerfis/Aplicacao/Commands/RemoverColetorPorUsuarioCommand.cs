using Dominio.Contratos.Commands.Base;
using System;

namespace Aplicacao.Commands
{
    public class RemoverColetorPorUsuarioCommand : RemoverCommand
    {
        public RemoverColetorPorUsuarioCommand(Guid id) : base(id)
        {

        }
    }
}
