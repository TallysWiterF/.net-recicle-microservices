using Core.Base;
using Dominio.Contratos.Commands.Comum;
using RecicleApiAcesso.Objetos;
using RecicleApiAcesso.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RecicleApiAcesso.Handlers
{
    public class ApiRecicleAcessoUsuarioClient : IBaseRequestHandler<AdicionarRegrasAcessoPerfilCommand, bool>
    {
        private readonly IApiRecicleAcesso _client;

        public ApiRecicleAcessoUsuarioClient(IApiRecicleAcesso client)
        {
            _client = client;
        }
        public async Task<bool> Handle(AdicionarRegrasAcessoPerfilCommand notification, CancellationToken cancellationToken)
        {
            var claims = new ClaimsCustom();
            claims.Claims.Add(new ClaimsCommand { Tipo = "IDPERFIL", Valor = notification.IdPerfil.ToString() });
            var response = await _client.PostAsync<object, ClaimsCustom>("adicionar-claims", claims);
            return response.Sucesso;
        }
    }
}
