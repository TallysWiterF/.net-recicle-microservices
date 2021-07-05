using Dominio.Contratos.Commands.Base;
using System;

namespace Dominio.Contratos.Commands
{
    public class RemoverAgendamentoCommand : RemoverCommand
    {
        public RemoverAgendamentoCommand(Guid id) : base(id)
        {
        }

        public RemoverAgendamentoCommand()
        {

        }
    }

    public class RemoverAgendamentosCommand : RemoverCommand
    {

        public new Guid? Id { get; set; }
        public Guid? IdItem { get; set; }
        public Guid? IdColetor { get; set; }

        public bool DadosPreenchidos()
        {
            return Id.HasValue || IdColetor.HasValue || IdItem.HasValue;
        }
    }
}
