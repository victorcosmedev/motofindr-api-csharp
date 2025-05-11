using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class MotoqueiroRepository : IMotoqueiroRepository
    {
        public Task<bool> AtualizarAsync(int id, MotoqueiroEntity moto)
        {
            throw new NotImplementedException();
        }

        public Task<MotoqueiroEntity?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoqueiroEntity>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MotoqueiroEntity> SalvarAsync(MotoqueiroEntity moto)
        {
            throw new NotImplementedException();
        }
    }
}
