using System;

namespace DomainReport.Worker.DTO
{
    public class CandidaturaReportDTO
    {
        public Guid IdCandidatura { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NumeroBI { get; set; }
        public string NumeroCandidatura { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public string EstadoCandidatura { get; set; }
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeProvincia { get; set; }
    }
}
