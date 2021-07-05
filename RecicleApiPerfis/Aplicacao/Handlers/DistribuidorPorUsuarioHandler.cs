using Aplicacao.Commands;
using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Contratos.Repositorios;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    class DistribuidorPorUsuarioHandler : IBaseRequestHandler<RemoverDistribuidorPorUsuarioCommand, bool>
    {
        private readonly IDistribuidorRepository _distribuidorRepository;
        private readonly IMediatorCustom _mediatorCustom;

        public DistribuidorPorUsuarioHandler(IDistribuidorRepository distribuidorRepository,
            IMediatorCustom mediatorCustom)
        {
            _distribuidorRepository = distribuidorRepository;
            _mediatorCustom = mediatorCustom;
        }

        public async Task<bool> Handle(RemoverDistribuidorPorUsuarioCommand request, CancellationToken cancellationToken)
        {
            var idDistribuidor = (await _distribuidorRepository.BuscarAsync(x => x.IdUser == request.Id)).Select(x => x.Id).First();
            return await _mediatorCustom.EnviarComandoAsync(new RemoverDistribuidorCommand(idDistribuidor));
        }
    }
}
