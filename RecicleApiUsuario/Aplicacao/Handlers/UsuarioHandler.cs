using Aplicacao.Commands;
using Aplicacao.Contratos;
using Aplicacao.Eventos;
using AutoMapper;
using Core.Base;
using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands;
using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class UsuarioHandler : IBaseRequestHandler<AddUsuarioCommand, Usuario>,
                                  IBaseRequestHandler<LogarUsuarioCommand, bool>,
                                  IBaseRequestHandler<GerarTokenCommand, UserResponse<string>>,
                                  IBaseRequestHandler<AdicionarClaimsCommand, bool>,
                                  IBaseRequestHandler<RemoverUsuarioCommand, bool>
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly AppJwtSettings _appJwtSettings;
        private readonly INotificador _notificator;
        private readonly IMediatorCustom _mediator;
        private readonly IUsuarioRequisicao _usuarioRequisicao;
        private readonly IMapper _mapper;

        public UsuarioHandler(SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            IOptions<AppJwtSettings> appJwtSettings,
            INotificador notificator,
            IMediatorCustom mediator,
            IUsuarioRequisicao usuarioRequisicao,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _notificator = notificator;
            _mediator = mediator;
            _usuarioRequisicao = usuarioRequisicao;
            _appJwtSettings = appJwtSettings.Value;
            _mapper = mapper;
        }

        public async Task<Usuario> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            var resultRegister = await _userManager.CreateAsync(request.Usuario, request.Senha);
            if (!resultRegister.Succeeded)
            {
                _notificator.AddRange(resultRegister.Errors.Select(x => x.Description).ToList(), EnumTipoMensagem.Warning);
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim("USUARIO", request.Usuario.Tipo.ToString().ToUpper())
            };
            var resultClaim = await _userManager.AddClaimsAsync(request.Usuario, claims);
            if (resultClaim.Succeeded) return request.Usuario;
            await _userManager.DeleteAsync(await _userManager.FindByEmailAsync(request.Usuario.Email));
            _notificator.AddRange(resultClaim.Errors.Select(x => x.Description).ToList(), EnumTipoMensagem.Warning);
            return null;
        }

        public async Task<bool> Handle(LogarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            var resultLogin = await _signInManager.PasswordSignInAsync(request.Email, request.Senha, true, true);
            if (resultLogin.Succeeded) return true;
            if (resultLogin.IsLockedOut)
            {
                _notificator.Add("Usuário temporariamente bloquado.", EnumTipoMensagem.Warning);
                return false;
            }
            _notificator.Add("Senha ou Usuário inválido.", EnumTipoMensagem.Warning);
            return false;
        }

        public async Task<bool> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                _notificator.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return false;
            }
            var resultRemove = await _userManager.DeleteAsync(user);
            if (resultRemove.Succeeded)
                await _mediator.PublicarEventoAsync(new UsuarioRemovidoEvent(_usuarioRequisicao));
            else
                _notificator.AddRange(resultRemove.Errors.Select(x => x.Description).ToList(), EnumTipoMensagem.Warning);
            return resultRemove.Succeeded;
        }

        public Task<UserResponse<string>> Handle(GerarTokenCommand request, CancellationToken cancellationToken)
        {
            var token = new JwtBuilder<Usuario>()
                    .WithUserManager(_userManager)
                    .WithJwtSettings(_appJwtSettings)
                    .WithEmail(request.Email)
                    .WithJwtClaims()
                    .WithUserClaims()
                    .BuildUserResponse();
            return Task.FromResult(token);
        }

        public async Task<bool> Handle(AdicionarClaimsCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            var user = await _userManager.FindByIdAsync(request.Id);
            var claims = _mapper.Map<List<Claim>>(request.Claims);
           var result = await _userManager.AddClaimsAsync(user, claims);
            if (!result.Succeeded)
             _notificator.Add("Ocorreu um erro ao inserir as novas claims.", EnumTipoMensagem.Warning);
            return result.Succeeded;
        }
    }
}
