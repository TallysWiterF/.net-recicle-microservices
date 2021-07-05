using Dominio.Contratos.Commands.Base;
using System;

namespace Dominio.Contratos.Commands.ItemCommands
{
    public class RemoverItemCommand : RemoverCommand
    {
        public RemoverItemCommand(Guid id) : base(id)
        {
        }
        public RemoverItemCommand()
        {

        }
    }

    public class RemoverItensCommand : RemoverCommand
    {
        public new Guid? Id { get; set; }
        public Guid? IdDistribuidor { get; set; }

        public bool DadosPreenchidos()
        {
            return Id.HasValue || IdDistribuidor.HasValue;
        }
    }
}
