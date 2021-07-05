using Core.Base;
using Dominio.Contratos.Commands.AgendamentoCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class AgendamentoHandler : IBaseRequestHandler<AddAgendamentoCommand, Agendamento>,
                                      IBaseRequestHandler<AtualizarAgendamentoCommand, Agendamento>,
                                      IBaseRequestHandler<RemoverAgendamentoCommand, bool>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly HandlerInjector _injector;

        public AgendamentoHandler(IAgendamentoRepository agendamentoRepository,HandlerInjector injector)
        {
            _agendamentoRepository = agendamentoRepository;
            _injector = injector;
        }

        public async Task<Agendamento> Handle(AddAgendamentoCommand request, CancellationToken cancellationToken)
        {
            await _agendamentoRepository.AddAsync(request.Agendamento);
            return request.Agendamento;
        }

        public async Task<Agendamento> Handle(AtualizarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            await _agendamentoRepository.AtualizarAsync(request.Agendamento);
            return request.Agendamento;
        }

        public async Task<bool> Handle(RemoverAgendamentoCommand request, CancellationToken cancellationToken)
        {
            await _agendamentoRepository.RemoverAsync(request.Id);
            return true;
        }
    }
}
