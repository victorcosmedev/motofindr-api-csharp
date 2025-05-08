namespace MotoFindrAPI.Application.DTOs
{
    public record VagaDTO
    {
        public int IdVaga { get; set; }
        public int SecaoId { get; set; }
        public int? MotoId { get; set; }
        public int NumeroVaga { get; set; }
        public bool Disponivel { get; set; }
    }
}
