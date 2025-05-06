using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_patio")]
    public class PatioEntity
    {
        [Key]
        public int IdPatio { get; set; }
        [Required]
        public double Largura { get; set; }
        [Required]
        public double Comprimento { get; set; }
        [JsonIgnore]
        public List<SecaoEntity>? Secoes { get; set; }
        public int VagasRestantes => Secoes?.Sum(secao => secao.VagasRestantes) ?? 0;

        public int RepartirVagas()
        {
            return 1;
        }
    }
}
