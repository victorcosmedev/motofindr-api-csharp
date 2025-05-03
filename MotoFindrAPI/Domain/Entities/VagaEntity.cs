namespace MotoFindrAPI.Domain.Entities
{
    public class VagaEntity
    {
        public int IdVaga { get; set; }
        public int SecaoId { get; set; }
        public MotoEntity Moto { get; set; }
        public SecaoEntity Secao {  get; set; }
        public int NumeroVaga { get; set; }
        public bool Disponivel { get; set; }
    }
}
