
namespace Domain.Entites
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Candidatura> Candidatura { get; set; }
    }
}
