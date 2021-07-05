using Dominio.Entidades;
using Dominio.ValuesTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mappings
{
    public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("AGENDAMENTO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("uniqueidentifier")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.IdItem)
                .HasColumnName("IDITEM")
                .HasColumnType("uniqueidentifier")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.IdColetor)
                .HasColumnName("IDCOLETOR")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            builder.Property(x => x.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(x => x.HoraColeta)
                .HasColumnName("HORACOLETA")
                .HasColumnType("integer")
                .IsRequired();
            builder.Property(x => x.MinutoColeta)
                .HasColumnName("MINUTOCOLETA")
                .HasColumnType("integer")
                .IsRequired();
            builder.Property(x => x.DiaDaSemanaColeta)
                .HasColumnName("DIADASEMANACOLETA")
                .HasColumnType("varchar(10)")
                .HasConversion(new EnumToStringConverter<EnumDiasDaSemana>())
                .IsRequired();
            builder.Property(x => x.Ativo)
               .HasColumnName("ATIVO")
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
