using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Mappings
{
    public class EstadoCandidaturaMap : IEntityTypeConfiguration<EstadoCandidatura>
    {
        public void Configure(EntityTypeBuilder<EstadoCandidatura> builder)
        {
            builder.ToTable("EstadoCandidatura");

            builder.HasKey(c => c.IdEstado);

            builder.Property(c => c.IdEstado)
             .IsRequired()
             .HasColumnName("IdEstado")
             .HasColumnType("int")
             .ValueGeneratedOnAdd();

            builder.Property(c => c.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(100)");
        }
    }
}
