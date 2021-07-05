using Core.Base;

namespace Dominio.Contratos.Commands
{
    public class RemoverUsuarioCommand : BaseCommand<bool>
    {
        public string Id { get; set; }

        public RemoverUsuarioCommand(string id)
        {
            Id = id;
        }
    }
}
