using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public  class CandidaturaMap:IEntityTypeConfiguration<Candidatura>
    {
        public void Configure(EntityTypeBuilder<Candidatura> builder)
        {
            builder.ToTable("Candidatura");
            builder.HasKey(c => c.IdCandidatura);
            builder.Property(c => c.IdCandidatura)
                .IsRequired()
                .HasColumnName("IdCandidatura")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(200)");
            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime");
            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DataCriacao")
                .HasColumnType("datetime");
            builder.Property(c => c.DataAtualizacao)
                .HasColumnType("datetime");
            builder.HasOne(c => c.Categoria)
                .WithMany(c => c.Candidatura)
                .HasForeignKey(c => c.IdCategoria);
            builder.HasOne(c => c.EstadoCandidatura)
               .WithMany(c => c.Candidatura)
               .HasForeignKey(c => c.IdEstadoCandidatura);
        }
    }
}
