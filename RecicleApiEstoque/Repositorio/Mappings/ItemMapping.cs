using Dominio.Entidades;
using Dominio.ValuesTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("ITEM");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IdDistribuidor);
            builder.Property(x => x.IdDistribuidor)
                .HasColumnName("IDDISTRIBUIDOR")
                .HasColumnType("uniqueidentifier")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.IdEstoque)
               .HasColumnName("IDESTOQUE")
               .HasColumnType("uniqueidentifier")
               .HasMaxLength(100)
               .IsRequired();
            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.TipoMaterial)
                .HasColumnName("TIPOMATERIAL")
                .HasColumnType("varchar(20)")
                .HasConversion(new EnumToStringConverter<EnumTipoMaterial>())
                .IsRequired();
          
            builder.Ignore(x => x.ErrosValidacao);
            builder.Ignore(x => x.IsValido);
            builder.HasOne(x => x.Estoque)
                .WithOne(x => x.Item)
                .HasForeignKey<Item>(x => x.IdEstoque)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
