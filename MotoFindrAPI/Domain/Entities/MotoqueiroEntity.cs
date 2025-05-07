using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFindrAPI.Domain.Entities
{
        public class MotoqueiroEntity : UserEntity
        {
            public int MotoId { get; set; }
            public MotoEntity? Moto { get; set; }
            public string Cnh { get; set; } = string.Empty;
            public EnderecoEntity? Endereco { get; set; }
        }
}
