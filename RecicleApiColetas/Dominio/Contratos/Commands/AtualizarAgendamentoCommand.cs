using System;

namespace Dominio.Contratos.Commands
{
    public class AtualizarAgendamentoCommand : BaseAgendamentoCommand
    {
        public Guid Id { get; init; }
        public bool Ativo { get; init; }
    }
}
