using AutoMapper;
using Core.Base;
using Core.Commands.Integracao;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;
using ViaCep.Contratos;

namespace ViaCep.Handlers
{
    public class BuscarEnderecoHandler : IBaseRequestHandler<BuscarEnderecoCommand<Endereco>, Endereco>
    {
        private readonly IGetEndereco _getEndereco;
        private readonly IMapper _mapper;
        public BuscarEnderecoHandler(IGetEndereco getEndereco, IMapper mapper)
        {
            _getEndereco = getEndereco;
            _mapper = mapper;
        }

        public async Task<Endereco> Handle(BuscarEnderecoCommand<Endereco> request, CancellationToken cancellationToken)
        {
            var endereco = await _getEndereco.GetEndereco(request.Cep);
            return _mapper.Map<Endereco>(endereco);
        }
    }
}
