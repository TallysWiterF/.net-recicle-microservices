using Dominio.Entidades;
using Dominio.ValuesTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("ESTOQUE");
            builder.HasKey(x => x.Id);
            //builder.HasIndex(x => x.IdItem);
            //builder.Property(x => x.IdItem)
            //    .HasColumnName("IDITEM")
            //    .HasColumnType("uniqueidentifier")
            //    .HasMaxLength(100)
            //    .IsRequired();
            builder.Property(x => x.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("numeric")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.DataAtualizacao)
                .HasColumnName("DATAATUALIZACAO")
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(x => x.TipoQuantidade)
              .HasColumnName("TIPOQUANTIDADE")
              .HasColumnType("varchar(20)")
              .HasConversion(new EnumToStringConverter<EnumTipoQuantidade>())
              .IsRequired();
            builder.Ignore(x => x.ErrosValidacao);
            builder.Ignore(x => x.IsValido);
            builder.HasOne(x => x.Item)
               .WithOne(x => x.Estoque)
               .HasForeignKey<Item>(x => x.IdEstoque);
        }
    }
}
