using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class EstadosCandidaturaRepository : IEstadosCandidaturaRepository
    {
        private readonly ApplicationDbContextGestCandidaturas _context;
        public EstadosCandidaturaRepository(ApplicationDbContextGestCandidaturas context)
        {
            _context = context;
        }
        public async Task<List<EstadoCandidatura>> GetAllEstados()
        {
            var estados = await _context.EstadoCandidatura
                .AsNoTracking()
                .ToListAsync();
            return estados;
        }
    }
}
