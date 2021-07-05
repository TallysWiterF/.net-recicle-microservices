using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class AgendamentoQueryHandler : IBaseRequestHandler<AgendamentoQuery, IEnumerable<Agendamento>>
    {
        private readonly IAgendamentoRepository _AgendamentoRepository;

        public AgendamentoQueryHandler(IAgendamentoRepository AgendamentoRepository)
        {
            _AgendamentoRepository = AgendamentoRepository;
        }

        public async Task<IEnumerable<Agendamento>> Handle(AgendamentoQuery request, CancellationToken cancellationToken)
        {
            return await _AgendamentoRepository.BuscarAsync(request);
        }
    }
}
