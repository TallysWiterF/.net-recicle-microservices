using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class DistribuidorQueryHandler : IBaseRequestHandler<DistribuidorQuery, IEnumerable<Distribuidor>>
    {
        private readonly IDistribuidorRepository _DistribuidorRepository;

        public DistribuidorQueryHandler(IDistribuidorRepository DistribuidorRepository)
        {
            _DistribuidorRepository = DistribuidorRepository;
        }

        public async Task<IEnumerable<Distribuidor>> Handle(DistribuidorQuery request, CancellationToken cancellationToken)
        {
            return await _DistribuidorRepository.BuscarAsync(request);
        }
    }
}
