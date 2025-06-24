using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContextGestCandidaturas _context;
        public CategoriaRepository(ApplicationDbContextGestCandidaturas context)
        {
            _context = context;
        }
   
        public async Task<bool> CriarCategoria(Categoria categoria)
        {   
            try
            {
                await _context.Categoria.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Categoria>> GetAllCategorias()
        {
            try
            {
                var categorias = await _context.Categoria
                    .AsNoTracking()
                    .ToListAsync();
                return categorias;
            }
            catch (Exception ex)
            {
                return new List<Categoria>();
            }

        }
    }
}
