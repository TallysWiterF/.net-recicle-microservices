using Crosscuting.Extensoes;
using Crosscuting.Funcoes;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Setup
{
    public class ApiBancoLeituraClient : IApiBancoLeituraClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiBancoLeituraClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TReturn> GetAsync<TReturn, TFilter>(string path, TFilter filtro = null) where TFilter : class
        {
            if (filtro is not null)
                path += filtro.GetQueryString();
            var body = await _clientFactory.CreateClient("ApiBancoLeitura").GetStringAsync(path);
            return JsonFunc.DeserializeObject<TReturn>(body);
        }
    }
}
