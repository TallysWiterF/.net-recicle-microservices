using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ItemCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;
using WebApi.Core.DTO;


namespace WebApi.Controllers
{
    [Authorize]
    [Route(RouteApi.BaseUrlApi)]
    public class EstoqueController : BaseController
    {
        public EstoqueController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPatch("repor")]
        [ProducesResponseType(typeof(EstoqueDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<EstoqueDTO>> Repor([FromBody] ReporItemEstoqueCommand request)
        {
            return CustomResponse(Mapper.Map<EstoqueDTO>(await Mediator.EnviarComandoAsync(request)));
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPatch("debitar")]
        [ProducesResponseType(typeof(EstoqueDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<EstoqueDTO>> Debitar([FromBody] DebitarItemEstoqueCommand request)
        {
            return CustomResponse(Mapper.Map<EstoqueDTO>(await Mediator.EnviarComandoAsync(request)));
        }
    }
}
