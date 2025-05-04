using Microsoft.EntityFrameworkCore;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<PatioEntity> Patio {  get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<MotoEntity> Moto { get; set; }
        public DbSet<MotoqueiroEntity> Motoqueiro { get; set; }
        public DbSet<VagaEntity> Vaga { get; set; }
    }
}
