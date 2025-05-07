using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IMotoApplicationService
    {
        Task<IEnumerable<MotoEntity>> BuscarTodasMotosAsync();
        Task<MotoEntity?> BuscarMotoPorIdAsync(int id);
        Task<MotoEntity> SalvarAsync(MotoDTO dto);
        Task<bool> AtualizarMotoAsync(int id, MotoEntity moto);
        Task<bool> DeletarMotoAsync(int id);
    }
}
