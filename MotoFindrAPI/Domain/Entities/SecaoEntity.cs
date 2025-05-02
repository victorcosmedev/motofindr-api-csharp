namespace MotoFindrAPI.Domain.Entities
{
    public class SecaoEntity
    {
        public int IdSecao { get; set; }
        public List<MotoEntity>? Motos { get; set; }
        public List<VagaEntity>? Vagas { get; set; }
        public int VagasRestantes { get => Vagas?.Count ?? 0; }
    }
}
