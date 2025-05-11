using MotoFindrAPI.Application.DTOs;

namespace MotoFindrAPI.Application.Interfaces
{
    public interface IMotoqueiroApplicationService
    {
        public Task<MotoqueiroDTO?> BuscarPorIdAsync(int id);
        public Task<IEnumerable<MotoqueiroDTO?>> BuscarTodosAsync();
        public Task<MotoqueiroDTO> SalvarAsync(MotoqueiroDTO dto);
        public Task<bool> AtualizarAsync(int id, MotoqueiroDTO dto);
        public Task<bool> DeletarAsync(int id);
    }
}
