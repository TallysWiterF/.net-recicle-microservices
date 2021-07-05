using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class AtualizarDistribuidorCommand : BaseCommand<Distribuidor>
    {
        public Distribuidor Distribuidor { get; init; }
    }
}
