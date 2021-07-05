using Dominio.Contratos.Commands.Base;
using System;

namespace Aplicacao.Commands
{
    public class RemoverDistribuidorPorUsuarioCommand : RemoverCommand
    {
        public RemoverDistribuidorPorUsuarioCommand(Guid id) : base(id)
        {

        }
    }
}
