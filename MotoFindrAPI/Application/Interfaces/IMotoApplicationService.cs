using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IMotoApplicationService
    {
        Task<IEnumerable<MotoEntity>> BuscarTodasMotosAsync();
        Task<MotoEntity?> BuscarMotoPorIdAsync(int id);
        Task<MotoEntity> SalvarAsync(MotoEntity patio);
        Task<bool> AtualizarMotoAsync(int id, MotoEntity moto);
        Task<bool> DeletarMotoAsync(int id);
    }
}
