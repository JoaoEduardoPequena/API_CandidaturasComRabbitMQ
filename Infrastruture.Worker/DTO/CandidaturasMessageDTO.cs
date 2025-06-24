namespace Infrastruture.Worker.DTO
{
    public class CandidaturasMessageDTO
    {
        public Guid IdCandidatura { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCricao { get; set; }
    }
}
