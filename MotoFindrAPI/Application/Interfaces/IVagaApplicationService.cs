using MotoFindrAPI.Application.DTOs;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IVagaApplicationService
    {
        Task<IEnumerable<VagaDTO?>> BuscarTodasVagasPorSecaoAsync(int secaoId);
        Task<IEnumerable<VagaDTO?>> BuscarTodasVagasPorPatioAsync(int patioId);
        Task<VagaDTO?> BuscarVagaPorIdAsync(int id);
        Task<VagaDTO> SalvarVagaAsync(VagaDTO dTO);
        Task<bool> AtualizarVagaAsync(int id, VagaDTO dTO);
        Task<bool> DeletarVagaAsync(int id);

    }
}
