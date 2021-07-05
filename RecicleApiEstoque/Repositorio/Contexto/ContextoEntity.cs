using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Repositorio.Contexto
{
    public class ContextoEntity : DbContext
    {
        public ContextoEntity(DbContextOptions<ContextoEntity> options) : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
