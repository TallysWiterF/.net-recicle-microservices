using Crosscuting.Funcoes;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecicleApiAcesso.Setup
{
    public class ApiRecicleAcesso : IApiRecicleAcesso
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiRecicleAcesso(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<(TReturn Response, bool Sucesso)> PostAsync<TReturn, TContent>(string path, TContent content)
        {
            var response = await _clientFactory.CreateClient("ApiRecicleAcesso").PostAsJsonAsync(path, content);
            if (response.IsSuccessStatusCode)
                return (JsonFunc.DeserializeObject<TReturn>(await response.Content.ReadAsStringAsync()), true);
            return (default(TReturn), false);
        }
    }
}
