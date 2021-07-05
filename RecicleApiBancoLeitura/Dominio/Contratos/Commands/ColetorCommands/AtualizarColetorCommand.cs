using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class AtualizarColetorCommand : BaseCommand<Coletor>
    {
        public Coletor Coletor { get; init; }
    }
}
