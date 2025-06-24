namespace Application.DTO.Candidaturas
{
    public class CandidaturaMessageDTO
    {
        public Guid IdCandidatura { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NumeroBI { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCricao { get; set; }
    }
}
