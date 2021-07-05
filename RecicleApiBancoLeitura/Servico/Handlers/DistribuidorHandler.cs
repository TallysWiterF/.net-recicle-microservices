using Core.Base;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class DistribuidorHandler : IBaseRequestHandler<AddDistribuidorCommand, Distribuidor>,
                                      IBaseRequestHandler<AtualizarDistribuidorCommand, Distribuidor>,
                                      IBaseRequestHandler<RemoverDistribuidorCommand, bool>
    {
        private readonly HandlerInjector _injector;
        private readonly IDistribuidorRepository _DistribuidorRepository;

        public DistribuidorHandler(IDistribuidorRepository DistribuidorRepository, HandlerInjector injector)
        {
            _DistribuidorRepository = DistribuidorRepository;
            _injector = injector;
        }

        public async Task<Distribuidor> Handle(AddDistribuidorCommand request, CancellationToken cancellationToken)
        {
            await _DistribuidorRepository.AddAsync(request.Distribuidor);
            return request.Distribuidor;
        }

        public async Task<Distribuidor> Handle(AtualizarDistribuidorCommand request, CancellationToken cancellationToken)
        {
            await _DistribuidorRepository.AtualizarAsync(request.Distribuidor);
            return request.Distribuidor;
        }

        public async Task<bool> Handle(RemoverDistribuidorCommand request, CancellationToken cancellationToken)
        {
            await _DistribuidorRepository.RemoverAsync(request.Id);
            return true;
        }
    }
}
