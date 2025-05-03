using System.ComponentModel.DataAnnotations;

namespace MotoFindrAPI.Domain.Entities
{
    public class PatioEntity
    {
        [Key]
        public int IdPatio { get; set; }
        [Required]
        public double Largura { get; set; }
        [Required]
        public double Comprimento { get; set; }
        public List<SecaoEntity>? Secoes { get; set; }
        public int VagasRestantes => Secoes?.Sum(secao => secao.VagasRestantes) ?? 0;

        public int RepartirVagas()
        {
            return 1;
        }
    }
}
