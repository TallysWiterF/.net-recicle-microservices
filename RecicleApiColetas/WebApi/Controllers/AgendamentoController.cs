using Crosscuting.Notificacao;
using Dominio.Contratos.Commands;
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
    [Route(RouteApi.BaseUrlApi + "/agendamento")]
    public class AgendamentoController : BaseController
    {
        public AgendamentoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [CustomAuthorize("USUARIO", "COLETOR")]
        [HttpPost]
        [ProducesResponseType(typeof(AgendamentoDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AgendamentoDTO>> Add([FromBody] AddAgendamentoCommand Agendamento)
        {
            return CustomResponse(Mapper.Map<AgendamentoDTO>(await Mediator.EnviarComandoAsync(Agendamento)), 201);
        }

        [CustomAuthorize("USUARIO", "COLETOR")]
        [HttpPut]
        [ProducesResponseType(typeof(AgendamentoDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AgendamentoDTO>> Put([FromBody] AtualizarAgendamentoCommand Agendamento)
        {
            return CustomResponse(Mapper.Map<AgendamentoDTO>(await Mediator.EnviarComandoAsync(Agendamento)));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new RemoverAgendamentoCommand { Id = id }));

        [HttpPatch("desativar/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Desativar([FromRoute] Guid id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new DesativarAgendamentoCommand(id)));

        [HttpPatch("ativar/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Ativar([FromRoute] Guid id)
            => CustomResponse(await Mediator.EnviarComandoAsync(new AtivarAgendamentoCommand(id)));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AgendamentoDTO>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<AgendamentoDTO>>> Get([FromQuery] AgendamentoQuery query)
            => CustomResponse(Mapper.Map<IEnumerable<AgendamentoDTO>>(await Mediator.EnviarComandoAsync(query)));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AgendamentoDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AgendamentoDTO>> GetId([FromRoute] Guid id)
            => CustomResponse(Mapper.Map<AgendamentoDTO>(
                (await Mediator.EnviarComandoAsync(new AgendamentoQuery { Id = id }))
                .FirstOrDefault()), 200, 404);
    }
}
