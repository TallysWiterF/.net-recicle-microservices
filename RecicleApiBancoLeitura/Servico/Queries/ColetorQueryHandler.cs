using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class ColetorQueryHandler : IBaseRequestHandler<ColetorQuery, IEnumerable<Coletor>>
    {
        private readonly IColetorRepository _coletorRepository;

        public ColetorQueryHandler(IColetorRepository coletorRepository)
        {
            _coletorRepository = coletorRepository;
        }

        public async Task<IEnumerable<Coletor>> Handle(ColetorQuery request, CancellationToken cancellationToken)
        {
            return await _coletorRepository.BuscarAsync(request);
        }
    }
}
