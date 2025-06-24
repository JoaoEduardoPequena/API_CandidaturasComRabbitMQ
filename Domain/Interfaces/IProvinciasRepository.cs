using Domain.Entites;

namespace Domain.Interfaces
{
    public interface IProvinciasRepository
    {
        public Task<List<Provincias>> GetAllProvincias();
    }
}
