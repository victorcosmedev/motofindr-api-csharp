using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_moto")]
    public class MotoEntity
    {
        [Key]
        public int Id { get; set; }
        public string NomeMoto { get; set; } = string.Empty;
        public string ModeloMoto { get; set; } = string.Empty;
        public int AnoMoto { get; set; }
        public string CorMoto { get; set; } = string.Empty;
        public int? MotoqueiroId { get; set; }
        public MotoqueiroEntity? Motoqueiro { get; set; }
        public int? VagaId { get; set; }
        public VagaEntity? Vaga { get; set; }
    }
}
