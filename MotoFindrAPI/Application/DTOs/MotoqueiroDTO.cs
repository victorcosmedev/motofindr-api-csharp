using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.DTOs
{
    public class MotoqueiroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public int MotoId { get; set; }
        public string Cnh { get; set; } = string.Empty;
        public string? Endereco { get; set; }
    }
}
