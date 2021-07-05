using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ColetorCommands;
using Dominio.Contratos.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using NetDevPack.Identity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Constantes;
using WebApi.Core.DTO;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(RouteApi.BaseUrlApi + "/coletor")]
    public class ColetorController : BaseController
    {
        public ColetorController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [CustomAuthorize("USUARIO", "COLETOR")]
        [HttpPost]
        [ProducesResponseType(typeof(ColetorDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ColetorDTO>> Add([FromBody] AddColetorCommand coletor)
        {
            coletor.IdUser = Guid.Parse(HttpContext.User.GetUserId());
            return CustomResponse(Mapper.Map<ColetorDTO>(await Mediator.EnviarComandoAsync(coletor)), 201);
        }

        [CustomAuthorize("USUARIO", "COLETOR")]
        [HttpPut]
        [ProducesResponseType(typeof(ColetorDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ColetorDTO>> Put([FromBody] AtualizarColetorCommand coletor)
        {
            coletor.IdUser = Guid.Parse(HttpContext.User.GetUserId());
            return CustomResponse(Mapper.Map<ColetorDTO>(await Mediator.EnviarComandoAsync(coletor)));
        }

        [CustomAuthorize("USUARIO", "COLETOR")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new RemoverColetorCommand { Id = id }));


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ColetorDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ColetorDTO>> GetId([FromRoute] Guid id)
            => CustomResponse(Mapper.Map<ColetorDTO>(
                (await Mediator.EnviarComandoAsync(new ColetorQuery { Id = id }))));
    }
}
