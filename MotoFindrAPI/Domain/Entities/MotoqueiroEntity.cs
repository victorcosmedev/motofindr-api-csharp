using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFindrAPI.Domain.Entities
{
        public class MotoqueiroEntity
        {
            public int Id { get; set; }
            public string NomeUser { get; set; } = string.Empty;
            public DateTime DataAniversarioUser { get; set; }
            public string CpfUser { get; set; } = string.Empty;
            public int MotoId { get; set; }
            public MotoEntity? Moto { get; set; }
            public string Cnh { get; set; } = string.Empty;
            public string? Endereco { get; set; }
        }
}
