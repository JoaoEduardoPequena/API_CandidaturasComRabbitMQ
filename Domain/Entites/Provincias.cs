namespace Domain.Entites
{
    public class Provincias
    {
        public int IdProvincia { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Candidatura> Candidatura { get; set; }
    }
}
