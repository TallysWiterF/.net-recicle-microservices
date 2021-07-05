using Crosscuting.Notificacao;
using Dominio.Contratos.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;
using WebApi.Core.DTO;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route(RouteApi.BaseUrlApi + "/distribuidor")]
    public class DistribuidorController : BaseController
    {
        public DistribuidorController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DistribuidorDTO>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<DistribuidorDTO>>> Get([FromQuery] DistribuidorQuery filter)
        {
            var dados = await Mediator.EnviarComandoAsync(filter);
            return CustomResponse(dados);
        }
    }
}
