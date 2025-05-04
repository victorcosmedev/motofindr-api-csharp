using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Application.Services
{
    public class MotoApplicationService : IMotoApplicationService
    {
        private readonly IMotoRepository _repository;
        public MotoApplicationService(IMotoRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> AtualizarMotoAsync(int id, MotoEntity moto)
        {
            //if(MotoqueiroPossuiOutraMoto(moto))
            //    throw new InvalidOperationException("Este motoqueiro já possui uma moto associada a ele.");
            //if (VagaJaEstaPreenchida(moto))
            //    throw new InvalidOperationException("Esta vaga já está ocupada");

            //try
            //{
            //    var sucesso = 
            //}
            throw new NotImplementedException();
        }

        public Task<MotoEntity?> BuscarMotoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MotoEntity>> BuscarTodasMotosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MotoEntity> SalvarAsync(MotoEntity patio)
        {
            throw new NotImplementedException();
        }

        private bool MotoqueiroPossuiOutraMoto(MotoEntity moto)
        {
            var motoqueiro = moto.motoqueiro;
            var motoDoMotoqueiro = motoqueiro != null ? motoqueiro.Moto : null;
            return motoDoMotoqueiro != null && motoDoMotoqueiro.Id != moto.Id;
        }

        private bool VagaJaEstaPreenchida(MotoEntity moto)
        {
            var vaga = moto.Vaga;
            var motoOcupandoAVaga = vaga.Moto;
            return motoOcupandoAVaga != null && motoOcupandoAVaga.Id != moto.Id;
        }
    }
}
