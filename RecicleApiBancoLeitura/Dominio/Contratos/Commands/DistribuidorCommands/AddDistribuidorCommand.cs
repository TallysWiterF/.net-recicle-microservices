using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class AddDistribuidorCommand : BaseCommand<Distribuidor>
    {
        public Distribuidor Distribuidor { get; init; }
    }
}
