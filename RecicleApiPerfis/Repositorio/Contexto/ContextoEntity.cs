using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Repositorio.Contexto
{
    public class ContextoEntity : DbContext
    {
        public ContextoEntity(DbContextOptions<ContextoEntity> options) : base(options)
        {
        }

        public DbSet<Coletor> Coletor { get; set; }
        public DbSet<Distribuidor> Distribuidor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
