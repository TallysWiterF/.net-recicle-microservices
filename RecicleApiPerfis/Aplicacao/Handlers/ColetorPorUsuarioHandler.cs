using Aplicacao.Commands;
using Core.Base;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Contratos.Repositorios;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class ColetorPorUsuarioHandler : IBaseRequestHandler<RemoverColetorPorUsuarioCommand, bool>
    {
        private readonly IColetorRepository _coletorRepository;
        private readonly IMediatorCustom _mediatorCustom;

        public ColetorPorUsuarioHandler(IColetorRepository coletorRepository,
            IMediatorCustom mediatorCustom)
        {
            _coletorRepository = coletorRepository;
            _mediatorCustom = mediatorCustom;
        }

        public async Task<bool> Handle(RemoverColetorPorUsuarioCommand request, CancellationToken cancellationToken)
        {
            var idColetor = (await _coletorRepository.BuscarAsync(x => x.IdUser == request.Id)).Select(x => x.Id).First();
            return await _mediatorCustom.EnviarComandoAsync(new RemoverColetorCommand(idColetor));
        }
    }
}
