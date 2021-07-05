using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Sincronizacao;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Dominio.Entidades.Entity
    {
        protected BaseRepositoryInjector Injector;


        public BaseRepository(BaseRepositoryInjector injector)
        {
            Injector = injector;
        }
        public IUnitOfWork UnitOfWork => Injector.UnitOfWork;

        public virtual async Task AddAsync(T entidade)
        {
            ValidarEntidade(entidade);
            await Injector.Context.Set<T>().AddAsync(entidade);
            Injector.Sincronizador.AddEvento(new AddSincronizacaoEvent<T> { Entidade = entidade });
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            await Task.Yield();
            var entidade = await BuscarPorIdAsync(id);
            if (entidade is null)
            {
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return;
            }
            Injector.Context.Set<T>().Remove(entidade);
            Injector.Sincronizador.AddEvento(new RemoverSincronizacaoEvent<T> { Entidade = entidade });
        }

        public virtual async Task RemoverRangeAsync(Expression<Func<T, bool>> filter)
        {
            await Task.Yield();
            var entidades = await BuscarAsync(filter);
            if (entidades is null || !entidades.Any())
            {
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return;
            }
            Injector.Context.Set<T>().RemoveRange(entidades);
            entidades.ToList().ForEach(x => 
                     Injector.Sincronizador.AddEvento(new RemoverSincronizacaoEvent<T> { Entidade = x }));
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            await Task.Yield();
            ValidarEntidade(entidade);

            if (!await ExisteAsync(x => x.Id == entidade.Id))
            {
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return;
            }

            Injector.Context.Set<T>().Update(entidade);
            Injector.Sincronizador.AddEvento(new AtualizarSincronizacaoEvent<T> { Entidade = entidade });
        }

        public virtual async Task AtualizarPropsAsync(T entidade, params string[] propriedades)
        {
            if (propriedades is null || !propriedades.Any())
            {
                await AtualizarAsync(entidade);
                return;
            }

            ValidarEntidade(entidade);

            var entityEntry = Injector.Context.Entry(entidade);

            foreach (var propriedade in propriedades)
                entityEntry.Property(propriedade).IsModified = true;

            Injector.Sincronizador.AddEvento(new AtualizarSincronizacaoEvent<T> { Entidade = entidade });
        }


        public virtual async Task<IQueryable<T>> BuscarAsync()
        {
            await Task.Yield();
            return Injector.Context.Set<T>().AsNoTracking();
        }

        public virtual async Task<IQueryable<T>> BuscarAsync(Expression<Func<T, bool>> filter, params string[] includes)
        {
            await Task.Yield();
            var query = Injector.Context.Set<T>().AsQueryable();

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            return query.AsNoTracking();
        }

        public virtual async Task<T> BuscarPorIdAsync(Guid id, params string[] includes)
        {
            var query = Injector.Context.Set<T>().AsQueryable();

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            var entidade = await query.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entidade is null)
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);

            return entidade;
        }

        public virtual async Task<bool> ExisteAsync(Expression<Func<T, bool>> filter)
        {
            return await Injector.Context.Set<T>().AnyAsync(filter);
        }

        #region Métodos Privados
        protected void ValidarEntidade<TEntidade>(TEntidade entidade) where TEntidade : Entity
        {
            if (!entidade.IsValido)
                throw new ArgumentException("Entidade inválida");
        }
        #endregion
    }
}
