using AutoMapper;
using Core.Base;
using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class AgendamentoHandler : IBaseRequestHandler<AddAgendamentoCommand, Agendamento>,
                                      IBaseRequestHandler<AtualizarAgendamentoCommand, Agendamento>,
                                      IBaseRequestHandler<RemoverAgendamentoCommand, bool>,
                                      IBaseRequestHandler<RemoverAgendamentosCommand, bool>,
                                      IBaseRequestHandler<DesativarAgendamentoCommand, bool>,
                                      IBaseRequestHandler<AtivarAgendamentoCommand, bool>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public AgendamentoHandler(IAgendamentoRepository agendamentoRepository, 
            INotificador notificador, 
            IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<Agendamento> Handle(AddAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Agendamento>(request);
            entidade.Ativar();
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao);
                return null;
            }
            if (await ValidarSeExisteAsync(entidade)) return null;
            await _agendamentoRepository.AddAsync(entidade);
            await _agendamentoRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Agendamento> Handle(AtualizarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Agendamento>(request);
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao);
                return null;
            }
            if (await ValidarSeExisteAsync(entidade)) return null;
            await _agendamentoRepository.AtualizarAsync(entidade);
            await _agendamentoRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> Handle(RemoverAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            await _agendamentoRepository.RemoverAsync(request.Id);
            return await _agendamentoRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(RemoverAgendamentosCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            if (!request.DadosPreenchidos()) return false;
            await _agendamentoRepository.RemoverRangeAsync(x =>
                    (!request.IdItem.HasValue || x.IdItem == request.IdItem.Value)
                    && (!request.IdColetor.HasValue || x.Id == request.IdColetor.Value)
                    && (!request.Id.HasValue || x.Id == request.Id.Value));
            return await _agendamentoRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(DesativarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            var entidade = await _agendamentoRepository.BuscarPorIdAsync(request.Id);
            if(entidade is null)
                return false;
            entidade.Desativar();
            await _agendamentoRepository.AtualizarPropsAsync(entidade, nameof(Agendamento.Ativo));
            return await _agendamentoRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> Handle(AtivarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            var entidade = await _agendamentoRepository.BuscarPorIdAsync(request.Id);
            if (entidade is null)
                return false;
            entidade.Ativar();
            await _agendamentoRepository.AtualizarPropsAsync(entidade, nameof(Agendamento.Ativo));
            return await _agendamentoRepository.UnitOfWork.CommitAsync();
        }

        #region Métodos Privados
        private async Task<bool> ValidarSeExisteAsync(Agendamento agendamento)
        {
            var existeAgendamento = await _agendamentoRepository.ExisteAsync(x => 
                                    x.Id != agendamento.Id
                                    && x.DiaDaSemanaColeta == agendamento.DiaDaSemanaColeta 
                                    && x.MinutoColeta == agendamento.MinutoColeta 
                                    && x.IdColetor == agendamento.IdColetor 
                                    && x.IdItem == agendamento.IdItem);
            if (existeAgendamento)
                _notificador.Add("Agendamento já existente para este item e neste dia.");

            return existeAgendamento;
        }
        #endregion
    }
}
