using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class ProvinciasRepository : IProvinciasRepository
    {
        private readonly ApplicationDbContextGestCandidaturas _context;
        public ProvinciasRepository(ApplicationDbContextGestCandidaturas context)
        {
            _context = context;
        }
        public async Task<List<Provincias>> GetAllProvincias()
        {
            try
            {
                var provincias = await _context.Provincias
                                 .AsNoTracking()
                                 .ToListAsync();
                return provincias;
            }
            catch (Exception ex)
            {
                return new List<Provincias>(); 
            } 
        }
    }
}
