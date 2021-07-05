using Aplicacao.Commands;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;
using WebApi.Core.DTO;

namespace WebApi.Controllers
{
    [Route(RouteApi.BaseUrlApi + "/usuario")]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioDTO>> Add([FromBody] UsuarioRegistroDTO request)
        {
            var usuario = Mapper.Map<Usuario>(request);
            var command = new AddUsuarioCommand();
            command.Usuario = usuario;
            command.Senha = request.Senha;
            return CustomResponse(Mapper.Map<UsuarioDTO>(await Mediator.EnviarComandoAsync(command)), 201);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UsuarioDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LogarUsuarioCommand request)
        {
            if (!await Mediator.EnviarComandoAsync(request))
                return CustomResponse(200, 401);
            var commandGerarToken = new GerarTokenCommand { Email = request.Email };
            return CustomResponse(await Mediator.EnviarComandoAsync(commandGerarToken), 200);
        }

        [Authorize]
        [HttpPost("adicionar-claims")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioDTO>> AdicionarClaims([FromBody] AdicionarClaimsCommand request)
        {
            request.Id = HttpContext.User.GetUserId();
            return CustomResponse(await Mediator.EnviarComandoAsync(request), 200);
        }

        [Authorize]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), 204)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Delete()
        {
            var id = HttpContext.User.GetUserId();
            await Mediator.EnviarComandoAsync(new RemoverUsuarioCommand(id));
            return CustomResponse(204, 400);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(UsuarioDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioDTO>> Get()
        {
            var queryCommand = new UsuarioQuery();
            queryCommand.Id = Guid.Parse(HttpContext.User.GetUserId());
            return CustomResponse(Mapper.Map<UsuarioDTO>(await Mediator.EnviarComandoAsync(queryCommand)));
        }
    }
}
