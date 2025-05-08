using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Domain.Entities;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IMotoApplicationService
    {
        Task<IEnumerable<MotoDTO>> BuscarTodasMotosPorPatioAsync();
        Task<MotoDTO?> BuscarMotoPorIdAsync(int id);
        Task<MotoDTO> SalvarAsync(MotoDTO dto);
        Task<bool> AtualizarMotoAsync(int id, MotoDTO moto);
        Task<bool> DeletarMotoAsync(int id);
        Task<IEnumerable<MotoDTO>> BuscarTodasMotosPorSecaoAsync(int secaoId);
    }
}
