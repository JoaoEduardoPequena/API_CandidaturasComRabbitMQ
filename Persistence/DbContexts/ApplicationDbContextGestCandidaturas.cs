using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.DbContexts
{
    public class ApplicationDbContextGestCandidaturas : DbContext
    {
        public ApplicationDbContextGestCandidaturas()
        {

        }
        public ApplicationDbContextGestCandidaturas(DbContextOptions<ApplicationDbContextGestCandidaturas> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoCandidatura> EstadoCandidatura { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NBUCLDSI-47;Database=BD_DevBantu;User ID=sa;Password=P3quen@123#;TrustServerCertificate=True");
        }
    }
}
