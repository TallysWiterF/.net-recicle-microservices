using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ItemCommands;
using Dominio.Contratos.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Constantes;
using WebApi.Core.DTO;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(RouteApi.BaseUrlApi + "/item")]
    public class ItemController : BaseController
    {
        public ItemController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPost]
        [ProducesResponseType(typeof(ItemDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ItemDTO>> Add([FromBody] AddItemCommand request)
        {
            return CustomResponse(Mapper.Map<ItemDTO>(await Mediator.EnviarComandoAsync(request)), 201);
        }

        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpPut]
        [ProducesResponseType(typeof(ItemDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ItemDTO>> Put([FromBody] AtualizarItemCommand request)
        {
            return CustomResponse(Mapper.Map<ItemDTO>(await Mediator.EnviarComandoAsync(request)));
        }


        [CustomAuthorize("USUARIO", "DISTRIBUIDOR")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new RemoverItemCommand { Id = id }));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ItemDTO>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get([FromQuery] ItemQuery query)
            => CustomResponse(Mapper.Map<IEnumerable<ItemDTO>>(await Mediator.EnviarComandoAsync(query)));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ItemDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ItemDTO>> GetId([FromRoute] Guid id)
            => CustomResponse(Mapper.Map<ItemDTO>(
                (await Mediator.EnviarComandoAsync(new ItemQuery { Id = id }))
                .FirstOrDefault()));
    }

   
}
