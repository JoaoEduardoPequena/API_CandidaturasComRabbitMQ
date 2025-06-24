namespace Domain.Entites
{
    public class EstadoCandidatura
    {
        public int IdEstado { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual ICollection<Candidatura> Candidatura { get; set; }
    }
}
