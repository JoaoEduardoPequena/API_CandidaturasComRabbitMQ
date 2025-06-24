using Domain.Entites;
using Domain.Interfaces;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class CandidaturaRepository : ICandidaturaRepository
    {
        private readonly ApplicationDbContextGestCandidaturas _context;

        public CandidaturaRepository(ApplicationDbContextGestCandidaturas context)
        {
            _context = context;
        }
        public async Task<bool> CriarCandidatura(Candidatura candidatura)
        {
            try
            {
                await _context.Candidatura.AddAsync(candidatura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
