using Dominio.Entidades;
using Dominio.ValuesTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Cep);
            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("uniqueidentifier").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cep).HasColumnName("CEP").HasColumnType("varchar(10)").IsRequired().HasMaxLength(10);
            builder.Property(x => x.Rua).HasColumnName("RUA").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60);
            builder.Property(x => x.Bairro).HasColumnName("BAIRRO").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60);
            builder.Property(x => x.Cidade).HasColumnName("CIDADE").HasColumnType("varchar(60)").IsRequired().HasMaxLength(60);
            builder.Property(x => x.Uf).HasColumnName("UF").HasColumnType("varchar(2)").HasConversion(new EnumToStringConverter<EnumUf>()).IsRequired();
            builder.Ignore(x => x.ErrosValidacao);
            builder.Ignore(x => x.IsValido);
        }
    }
}
