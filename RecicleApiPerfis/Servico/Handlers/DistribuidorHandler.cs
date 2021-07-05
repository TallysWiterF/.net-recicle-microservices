using AutoMapper;
using Core.Base;
using Core.Commands.Integracao;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.Comum;
using Dominio.Contratos.Commands.DistribuidorCommands;
using Dominio.Contratos.Eventos.DistribuidorEventos;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class DistribuidorHandler : IBaseRequestHandler<AddDistribuidorCommand, Distribuidor>,
                                  IBaseRequestHandler<AtualizarDistribuidorCommand, Distribuidor>,
                                  IBaseRequestHandler<RemoverDistribuidorCommand, bool>
    {
        private bool _novoEndereco = false;
        private readonly IDistribuidorRepository _distribuidorRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly IMediatorCustom _mediatorCustom;

        public DistribuidorHandler(IDistribuidorRepository distribuidorRepository,
            INotificador notificador, 
            IMapper mapper, 
            IMediatorCustom mediatorCustom)
        {
            _distribuidorRepository = distribuidorRepository;
            _notificador = notificador;
            _mapper = mapper;
            _mediatorCustom = mediatorCustom;
        }

        public async Task<Distribuidor> Handle(AddDistribuidorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Distribuidor>(request);
            await DefinirEnderecoAsync(entidade, request.Cep);
            if (!await ValidarAsync(entidade, request.Cep)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _distribuidorRepository.AddAsync(entidade, _novoEndereco);
            await _distribuidorRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Distribuidor> Handle(AtualizarDistribuidorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var entidade = _mapper.Map<Distribuidor>(request);
            await DefinirEnderecoAsync(entidade, request.Cep);
            if (!await ValidarAsync(entidade, request.Cep)) return null;
            if (!entidade.IsValido)
            {
                _notificador.AddRange(entidade.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            await _distribuidorRepository.AtualizarAsync(entidade, _novoEndereco);
            await _distribuidorRepository.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<bool> Handle(RemoverDistribuidorCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            await _distribuidorRepository.RemoverAsync(request.Id);
            var result = await _distribuidorRepository.UnitOfWork.CommitAsync();
            if (result)
                await _mediatorCustom.PublicarEventoAsync(new DistribuidorRemovidoEvent(request.Id));
            return result;
        }

        #region Metodos Privados
        private async Task<bool> ValidarAsync(Distribuidor distribuidor, string cep)
        {
            var distribuidorCollection = (await _distribuidorRepository
                .BuscarAsync(x => 
                    x.Id != distribuidor.Id &&
                    x.Email.Equals(distribuidor.Email)))
                .ToList();

            if (distribuidorCollection != null && distribuidorCollection.Any())
            {
                if ((distribuidorCollection.Where(x => x.Email.Equals(distribuidor.Email))).Any())
                {
                    _notificador.Add("Email inserido já está sendo usado.", EnumTipoMensagem.Warning);
                    return false;
                }
            }
            return true;
        }

        private async Task DefinirEnderecoAsync(Distribuidor distribuidor, string cep)
        {
            var endereco = (await _distribuidorRepository.BuscarEnderecoAsync(x => x.Cep == cep)).FirstOrDefault();
            _novoEndereco = endereco is null;
            if (endereco is null)
                endereco = await _mediatorCustom.EnviarComandoAsync(new BuscarEnderecoCommand<Endereco>(cep));
            distribuidor.DefinirEndereco(endereco);
        }
        #endregion
    }
}
