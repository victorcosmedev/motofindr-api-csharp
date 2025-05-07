using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Domain.Interfaces
{
    public interface IMotoqueiroRepository
    {
        Task<IEnumerable<MotoqueiroEntity>> BuscarTodosAsync();
        Task<MotoqueiroEntity?> BuscarPorIdAsync(int id);
        Task<MotoqueiroEntity> SalvarAsync(MotoqueiroEntity moto);
        Task<bool> AtualizarAsync(int id, MotoqueiroEntity moto);
        Task<bool> DeletarAsync(int id);
    }
}
