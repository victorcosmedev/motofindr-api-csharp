using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<MotoEntity>> BuscarTodasAsync();
        Task<MotoEntity?> BuscarPorIdAsync(int id);
        Task<MotoEntity> SalvarAsync(MotoEntity patio);
        Task<bool> AtualizarAsync(int id, MotoEntity moto);
        Task<bool> DeletarAsync(int id);
    }
}
