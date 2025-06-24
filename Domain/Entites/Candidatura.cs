namespace Domain.Entites
{
    public class Candidatura
    {
        public Guid IdCandidatura { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NumeroBI { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string NumeroCandidatura { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdEstadoCandidatura { get; set; }
        public EstadoCandidatura EstadoCandidatura { get; set; }
        public int IdProvincia { get; set; }
        public Provincias Provincias { get; set; }
    }
}
