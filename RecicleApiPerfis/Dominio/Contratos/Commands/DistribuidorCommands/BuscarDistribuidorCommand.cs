using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.DistribuidorCommands
{
    public class BuscarDistribuidorCommand : BaseCommand<Distribuidor>
    {
        public DistribuidorQuery Query { get; set; }

        public BuscarDistribuidorCommand(DistribuidorQuery query)
        {
            Query = query;
        }
    }
}
