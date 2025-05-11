using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IMotoqueiroRepository
    {
        Task<IEnumerable<MotoqueiroEntity>> BuscarTodosAsync();
        Task<MotoqueiroEntity?> BuscarPorIdAsync(int id);
        Task<MotoqueiroEntity> SalvarAsync(MotoqueiroEntity entity);
        Task<bool> AtualizarAsync(int id, MotoqueiroEntity entity);
        Task<bool> DeletarAsync(int id);
    }
}
