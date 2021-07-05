using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;
using Repositorio.Sincronizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class DistribuidorRepository : BaseRepository<Distribuidor>, IDistribuidorRepository
    {
        public DistribuidorRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public Task<IQueryable<Endereco>> BuscarEnderecoAsync(Expression<Func<Endereco, bool>> filter = null)
        {
            return Task.FromResult(Injector.Context.Endereco.Where(filter));
        }

        public async Task AddAsync(Distribuidor entidade, bool novoEndereco = true)
        {
            if (!novoEndereco)
                Injector.Context.Entry(entidade.Endereco).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            await base.AddAsync(entidade);
        }

        public async Task AtualizarAsync(Distribuidor entidade, bool novoEndereco = true)
        {
            if (!novoEndereco)
                Injector.Context.Entry(entidade.Endereco).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            await base.AtualizarAsync(entidade);
        }

        public Task<IEnumerable<Distribuidor>> BuscarAsync(DistribuidorQuery filter)
        {
            return Task.FromResult
                (
                    (Injector.Context.Distribuidor
                    .Where(x => (!filter.Id.HasValue || x.Id == filter.Id.Value)
                                && (!filter.IdUser.HasValue || x.IdUser == filter.IdUser.Value)
                                && (!filter.IdItem.HasValue || x.IdUser == filter.IdItem.Value)
                     ))
                     .AsEnumerable()
                 );
        }
    }
}
