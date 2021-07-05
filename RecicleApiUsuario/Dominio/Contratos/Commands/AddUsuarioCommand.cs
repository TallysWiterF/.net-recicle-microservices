using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands
{
    public class AddUsuarioCommand : BaseCommand<Usuario>
    {
        public Usuario Usuario { get; set; }
        public string Senha { get; set; }
    }
}
