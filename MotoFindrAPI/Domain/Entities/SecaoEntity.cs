using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_secao")]
    public class SecaoEntity
    {
        [Key]
        public int IdSecao { get; set; }
        public int PatioId { get; set; }
        [JsonIgnore]
        public PatioEntity? Patio { get; set; }
        [JsonIgnore]
        public List<VagaEntity>? Vagas { get; set; }
        public int VagasRestantes => Vagas?.Count(vaga => vaga.Disponivel) ?? 0;
    }
}
