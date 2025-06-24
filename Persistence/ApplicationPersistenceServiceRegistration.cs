using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class ApplicationPersistenceServiceRegistration
    {
        public static void AddInfraPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContextGestCandidaturas>(o => o.UseSqlServer(configuration.GetConnectionString("Connection"),
                builderOp => builderOp.MigrationsAssembly(typeof(ApplicationDbContextGestCandidaturas).Assembly.FullName)));

            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IEstadosCandidaturaRepository, EstadosCandidaturaRepository>();
            services.AddTransient<IProvinciasRepository, ProvinciasRepository>();
            services.AddTransient<ICandidaturaRepository, CandidaturaRepository>();
        }
    }
}
