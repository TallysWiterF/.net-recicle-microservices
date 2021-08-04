using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class ColetorMapping : IEntityTypeConfiguration<Coletor>
    {
        public void Configure(EntityTypeBuilder<Coletor> builder)
        {
            builder.ToTable("COLETOR");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IdUser);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.IdUser).HasColumnName("IDUSER").HasColumnType("uniqueidentifier").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).HasColumnName("TELEFONE").HasColumnType("varchar(11)").IsUnicode(false).IsRequired().HasMaxLength(11);
            builder.Ignore(x => x.ErrosValidacao);
            builder.Ignore(x => x.IsValido);
            builder.Property(x => x.DataCriacao).HasColumnName("DATACRIACAO").HasColumnType("datetime").IsRequired();
        }
    }
}
