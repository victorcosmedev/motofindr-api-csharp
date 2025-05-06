using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFindrAPI.Domain.Entities
{
    [Table("tb_mf_endereco")]
    public class EnderecoEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
    }
}
