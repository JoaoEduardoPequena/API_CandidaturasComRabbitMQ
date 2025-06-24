using Domain.Entites;

namespace Domain.Interfaces
{
    public  interface ICategoriaRepository
    {
        public Task<bool> CriarCategoria(Categoria categoria);
        public Task<List<Categoria>> GetAllCategorias();
    }
}
