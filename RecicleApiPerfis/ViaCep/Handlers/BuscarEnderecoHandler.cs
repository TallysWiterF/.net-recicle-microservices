using AutoMapper;
using Core.Base;
using Core.Commands.Integracao;
using Crosscuting.Funcoes;
using Dominio.Entidades;
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
        public BuscarEnderecoHandler(IHttpClientFactory factory, 
            IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<Endereco> Handle(BuscarEnderecoCommand<Endereco> request, CancellationToken cancellationToken)
        {
            var endereco = await _factory.CreateClient("ApiViaCep").GetStringAsync($"{request.Cep}/json");
            return _mapper.Map<Endereco>(JsonFunc.DeserializeObject<EnderecoResponse>(endereco));
        }
    }
}
