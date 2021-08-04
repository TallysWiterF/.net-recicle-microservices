using Crosscuting.Extensoes;
using Crosscuting.Funcoes;
using Crosscuting.Notificacao;
using Resiliencia.Objetos;
using Resiliencia.Setup;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Setup
{
    public class ApiBancoLeituraClient : IApiBancoLeituraClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly INotificador _notificador;
        private readonly IPollyFactory _polly;

        public ApiBancoLeituraClient(IHttpClientFactory clientFactory,
            INotificador notificador,
            IPollyFactory polly)
        {
            _clientFactory = clientFactory;
            _notificador = notificador;
            _polly = polly;
        }

        public async Task<TReturn> GetAsync<TReturn, TFilter>(string path, TFilter filtro = null) where TFilter : class
        {
            if (filtro is not null)
                path += filtro.GetQueryString();
            var setup = CriarSetupResiliencia(_clientFactory.CreateClient("ApiBancoLeitura").GetStringAsync(path));
            return JsonFunc.DeserializeObject<TReturn>(await _polly.CreateWaitAndRetryAsync(setup));
        }

        private PollyParametrizacaoRetryAndWait<TReturn> CriarSetupResiliencia<TReturn>(Task<TReturn> taskHandler)
        {
            var setup = PollyParametrizacaoRetryAndWait<TReturn>.SetupDefault();
            setup.TaskHandler = async () => await taskHandler;
            setup.PollyExceptionHandler = (endereco, exception, retry) => _notificador.Add("Ocorreu um erro interno.", EnumTipoMensagem.Erro);
            return setup;
        }
    }
}
