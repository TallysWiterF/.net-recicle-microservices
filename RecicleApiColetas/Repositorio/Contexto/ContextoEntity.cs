using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Repositorio.Contexto
{
    public class ContextoEntity : DbContext
    {
        public ContextoEntity(DbContextOptions<ContextoEntity> options) : base(options)
        {
        }

        public DbSet<Agendamento> Agendamento { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
