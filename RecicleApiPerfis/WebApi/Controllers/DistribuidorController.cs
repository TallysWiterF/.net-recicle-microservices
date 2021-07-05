using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.DistribuidorCommands;
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
    [Route(RouteApi.BaseUrlApi + "/distribuidor")]
    public class DistribuidorController : BaseController
    {

        public DistribuidorController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPost]
        [ProducesResponseType(typeof(DistribuidorDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DistribuidorDTO>> Add([FromBody] AddDistribuidorCommand distribuidor)
        {
            distribuidor.IdUser = Guid.Parse(HttpContext.User.GetUserId());
            return CustomResponse(Mapper.Map<DistribuidorDTO>(await Mediator.EnviarComandoAsync(distribuidor)), 201);
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPut]
        [ProducesResponseType(typeof(DistribuidorDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DistribuidorDTO>> Put([FromBody] AtualizarDistribuidorCommand distribuidor)
        {
            distribuidor.IdUser = Guid.Parse(HttpContext.User.GetUserId());
            return CustomResponse(Mapper.Map<DistribuidorDTO>(await Mediator.EnviarComandoAsync(distribuidor)));
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid Id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new RemoverDistribuidorCommand { Id = Id }));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DistribuidorDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DistribuidorDTO>> GetId([FromRoute] Guid id)
            => CustomResponse(Mapper.Map<DistribuidorDTO>(
                (await Mediator.EnviarComandoAsync(new DistribuidorQuery { Id = id }))), 200, 404);
    }
}
