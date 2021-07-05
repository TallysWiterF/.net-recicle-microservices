using Core.Base;
using NetDevPack.Identity.Jwt.Model;

namespace Aplicacao.Commands
{
    public class GerarTokenCommand : BaseCommand<UserResponse<string>>
    {
        public string Email { get; set; }
    }
}
