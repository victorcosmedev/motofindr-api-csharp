using System.ComponentModel.DataAnnotations;

namespace MotoFindrAPI.Domain.Entities
{
    public class SecaoEntity
    {
        public int IdSecao { get; set; }
        
        public int PatioId { get; set; }        
        public required PatioEntity Patio { get; set; }
        public List<MotoEntity>? Motos { get; set; }
        public List<VagaEntity>? Vagas { get; set; }
        public int VagasRestantes => Vagas?.Count(vaga => vaga.Disponivel) ?? 0;
    }
}
