namespace MotoFindrAPI.Domain.Entities
{
    public class MotoqueiroEntity : UserEntity
    {
        public MotoEntity? Moto { get; set; }
        public string Cnh { get; set; } = string.Empty;
        public EnderecoEntity? Endereco { get; set; }
    }
}
