using AutoMapper;
using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Contratos.Commands.Comum;
using Dominio.Contratos.Eventos.ColetorEventos;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class ColetorHandler : IBaseRequestHandler<AddColetorCommand, Coletor>,
                                  IBaseRequestHandler<AtualizarColetorCommand, Coletor>,
                                  IBaseRequestHandler<RemoverColetorCommand, bool>
    {
        private readonly IColetorRepository _coletorRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly IMediatorCustom _mediator;

        public ColetorHandler(IColetorRepository coletorRepository, 
            INotificador notificador, 
            IMapper mapper, 
            IMediatorCustom mediator)
        {
            _coletorRepository = coletorRepository;
            _notificador = notificador;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<Coletor> Handle(AddColetorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Coletor>(request);
            if (!await ValidarAsync(entidade)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _coletorRepository.AddAsync(entidade);
            await _coletorRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Coletor> Handle(AtualizarColetorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Coletor>(request);
            if (!await ValidarAsync(entidade)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _coletorRepository.AtualizarAsync(entidade);
            await _coletorRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> Handle(RemoverColetorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            await _coletorRepository.RemoverAsync(request.Id);
            var result = await _coletorRepository.UnitOfWork.CommitAsync();
            if (result)
                await _mediator.PublicarEventoAsync(new ColetorRemovidoEvent(request.Id));
            return result;
        }

        #region Metodos Privados
        private async Task<bool> ValidarAsync(Coletor coletor)
        {
            var existe = await _coletorRepository.ExisteAsync(x => x.Id != coletor.Id && x.IdUser == coletor.IdUser);
            return !existe;
        }
        #endregion
    }
}
