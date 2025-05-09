using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IVagaRepository
    {
        Task<IEnumerable<VagaEntity?>> BuscarTodasVagasPorSecaoAsync(int secaoId);
        Task<IEnumerable<VagaEntity?>> BuscarTodasVagasPorPatioAsync(int patioId);
        Task<VagaEntity?> BuscarVagaPorIdAsync(int id);
        Task<VagaEntity> SalvarAsync(VagaEntity vaga);
        Task<bool> AtualizarAsync(int id, VagaEntity vaga);
        Task<bool> DeletarAsync(int id);
    }
}
