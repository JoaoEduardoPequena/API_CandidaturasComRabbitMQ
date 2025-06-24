using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.IdCategoria);

            builder.Property(c => c.IdCategoria)
             .IsRequired()
             .HasColumnName("IdCategoria")
             .HasColumnType("int")
             .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(200)");
        }
    }
}
