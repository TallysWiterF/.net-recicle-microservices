using AutoMapper;
using Core.Base;
using Core.Commands.Integracao;
using Crosscuting.Funcoes;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Resiliencia.Objetos;
using Resiliencia.Setup;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ViaCep.Objetos;

namespace ViaCep.Handlers
{
    public class BuscarEnderecoHandler : IBaseRequestHandler<BuscarEnderecoCommand<Endereco>, Endereco>
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _factory;
        private readonly IPollyFactory _polly;
        private readonly INotificador _notificador;
        public BuscarEnderecoHandler(IHttpClientFactory factory,
            IMapper mapper,
            IPollyFactory polly,
            INotificador notificador)
        {
            _factory = factory;
            _mapper = mapper;
            _polly = polly;
            _notificador = notificador;
        }

        public async Task<Endereco> Handle(BuscarEnderecoCommand<Endereco> request, CancellationToken cancellationToken)
        {
            var endereco = await _polly.CreateWaitAndRetryAsync(CriarSetupResiliencia(request));
            return _mapper.Map<Endereco>(endereco);
        }

        private PollyParametrizacaoRetryAndWait<EnderecoResponse> CriarSetupResiliencia(BuscarEnderecoCommand<Endereco> request)
        {
            var setup = PollyParametrizacaoRetryAndWait<EnderecoResponse>.SetupDefault();
            setup.TaskHandler = async () =>
            {
                var response = await _factory.CreateClient("ApiViaCep").GetStringAsync($"{request.Cep}/json");
                return JsonFunc.DeserializeObject<EnderecoResponse>(response);
            };
            setup.PollyExceptionHandler = (endereco, exception, retry) => _notificador.Add("Ocorreu um erro ao buscar o Endereço.", EnumTipoMensagem.Erro);
            return setup;
        }
    }
}
