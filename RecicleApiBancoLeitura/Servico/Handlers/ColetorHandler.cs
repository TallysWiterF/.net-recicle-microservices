using Core.Base;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class ColetorHandler : IBaseRequestHandler<AddColetorCommand, Coletor>,
                                      IBaseRequestHandler<AtualizarColetorCommand, Coletor>,
                                      IBaseRequestHandler<RemoverColetorCommand, bool>
    {
        private readonly HandlerInjector _injector;
        private readonly IColetorRepository _ColetorRepository;

        public ColetorHandler(IColetorRepository ColetorRepository, HandlerInjector injector)
        {
            _ColetorRepository = ColetorRepository;
            _injector = injector;
        }

        public async Task<Coletor> Handle(AddColetorCommand request, CancellationToken cancellationToken)
        {
            await _ColetorRepository.AddAsync(request.Coletor);
            return request.Coletor;
        }

        public async Task<Coletor> Handle(AtualizarColetorCommand request, CancellationToken cancellationToken)
        {
            await _ColetorRepository.AtualizarAsync(request.Coletor);
            return request.Coletor;
        }

        public async Task<bool> Handle(RemoverColetorCommand request, CancellationToken cancellationToken)
        {
            await _ColetorRepository.RemoverAsync(request.Id);
            return true;
        }
    }
}
