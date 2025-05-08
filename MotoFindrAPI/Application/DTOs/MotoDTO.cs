namespace MotoFindrAPI.Application.DTOs
{
    public record MotoDTO
    {
        public int Id { get; set; }
        public string NomeMoto { get; set; } = string.Empty;
        public string ModeloMoto { get; set; } = string.Empty;
        public int AnoMoto { get; set; }
        public string CorMoto { get; set; } = string.Empty;
        public int? MotoqueiroId { get; set; }
        public int? VagaId { get; set; }
    }
}
