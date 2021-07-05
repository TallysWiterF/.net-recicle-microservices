using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class DistribuidorMapping : IEntityTypeConfiguration<Distribuidor>
    {
        public void Configure(EntityTypeBuilder<Distribuidor> builder)
        {
            builder.ToTable("DISTRIBUIDOR");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IdUser);
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).HasColumnName("TELEFONE").HasColumnType("varchar(11)").IsUnicode(false).IsRequired().HasMaxLength(11);
            builder.Property(x => x.IdUser).HasColumnName("IDUSER").HasColumnType("uniqueidentifier").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.NumeroResidencia).HasColumnName("NUMERORESIDENCIA").HasColumnType("varchar(10)").IsUnicode(false).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Latitude).HasColumnName("LATITUDE").HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.Longitude).HasColumnName("LONGITUDE").HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.DataCriacao).HasColumnName("DATACRIACAO").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.IdEndereco).HasColumnName("IDENDERECO").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Ignore(x => x.ErrosValidacao);
            builder.Ignore(x => x.IsValido);
            builder.HasOne<Endereco>().WithMany().HasForeignKey(x => x.IdEndereco).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
