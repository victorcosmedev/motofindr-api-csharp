using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IVagaRepository
    {
        Task<IEnumerable<VagaEntity>> BuscarTodasAsync();
        Task<VagaEntity?> BuscarPorIdAsync(int id);
        Task<VagaEntity> SalvarAsync(VagaEntity vaga);
        Task<bool> AtualizarAsync(int id, VagaEntity vaga);
        Task<bool> DeletarAsync(int id);
    }
}
