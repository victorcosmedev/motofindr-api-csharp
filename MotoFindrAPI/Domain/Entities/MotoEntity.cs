using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_moto")]
    public class MotoEntity
    {
        [Key]
        public int Id { get; set; }
        public string nomeMoto { get; set; } = string.Empty;
        public string modeloMoto { get; set; } = string.Empty;
        public int anoMoto { get; set; }
        public string corMoto { get; set; } = string.Empty;
        public MotoqueiroEntity? motoqueiro { get; set; }
        public int VagaId { get; set; }
        public VagaEntity? Vaga { get; set; }
    }
}
