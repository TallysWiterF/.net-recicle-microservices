using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.ColetorCommands
{
    public class BuscarColetorCommand : BaseCommand<Coletor>
    {
        public ColetorQuery Query { get; set; }

        public BuscarColetorCommand(ColetorQuery query)
        {
            Query = query;
        }
    }
}
