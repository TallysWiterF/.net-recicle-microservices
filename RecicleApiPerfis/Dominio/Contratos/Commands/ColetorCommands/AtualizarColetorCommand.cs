using System;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class AtualizarColetorCommand : BaseColetorCommand<Entidades.Coletor>
    {
        public Guid Id { get; set; }
    }
}
