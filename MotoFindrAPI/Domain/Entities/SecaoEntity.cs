using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotoFindrAPI.Domain.Entities
{
    public class SecaoEntity
    {
        public int IdSecao { get; set; }
        public int PatioId { get; set; }
        [JsonIgnore]
        public PatioEntity Patio { get; set; }
        public List<VagaEntity>? Vagas { get; set; }
        public int VagasRestantes => Vagas?.Count(vaga => vaga.Disponivel) ?? 0;
    }
}
