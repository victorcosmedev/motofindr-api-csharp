using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IPatioRepository
    {
        Task<IEnumerable<PatioEntity>> BuscarTodosAsync();
        Task<PatioEntity?> BuscarPorIdAsync(int id);
        Task<PatioEntity> AdicionarAsync(PatioEntity patio);
        Task<bool> AtualizarAsync(int id, PatioEntity patioAtualizado);
        Task<bool> DeletarAsync(int id);
        Task<PatioEntity> SalvarAsync(PatioEntity patio);
    }
}
