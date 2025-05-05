using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Infrastructure.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        public Task<bool> AtualizarAsync(int id, MotoEntity moto)
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoEntity>> BuscarTodasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity> SalvarAsync(MotoEntity patio)
        {
            throw new NotImplementedException();
        }
    }
}
