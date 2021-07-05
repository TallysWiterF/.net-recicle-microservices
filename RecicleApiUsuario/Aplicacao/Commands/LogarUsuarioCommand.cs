using Core.Base;

namespace Aplicacao.Commands
{
    public class LogarUsuarioCommand : BaseCommand<bool>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
