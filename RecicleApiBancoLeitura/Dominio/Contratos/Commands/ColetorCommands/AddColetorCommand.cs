using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class AddColetorCommand : BaseCommand<Coletor>
    {
        public Coletor Coletor { get; init; }
    }
}
