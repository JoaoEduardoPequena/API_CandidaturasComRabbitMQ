using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entites;
namespace Persistence.Mappings
{
    public class ProvinciasMap : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> builder)
        {
            builder.ToTable("Provincias");

            builder.HasKey(c => c.IdProvincia);

            builder.Property(c => c.IdProvincia)
             .IsRequired()
             .HasColumnName("Nome")
             .HasColumnType("int")
             .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(100)");
        }
    }
}
