using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_vaga")]
    public class VagaEntity
    {
        [Key]
        public int IdVaga { get; set; }
        public int SecaoId { get; set; }
        public int MotoId { get; set; }
        public MotoEntity? Moto { get; set; }
        [JsonIgnore]
        public SecaoEntity? Secao {  get; set; }
        public int NumeroVaga { get; set; }
        public bool Disponivel { get; set; }
    }
}
