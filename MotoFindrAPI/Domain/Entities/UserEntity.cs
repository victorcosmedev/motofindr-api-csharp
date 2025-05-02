namespace MotoFindrAPI.Domain.Entities
{
    public abstract class UserEntity
    {
        public int Id { get; set; }
        public string NomeUser { get; set; } = string.Empty;
        public DateTime DataAniversarioUser { get; set; }
        public string CpfUser { get; set; } = string.Empty;

        public bool VerificarCpf(string cpf)
        {
            return true;
        }
    }
}
