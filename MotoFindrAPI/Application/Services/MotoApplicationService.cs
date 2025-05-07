using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Application.Interfaces;
using MotoFindrAPI.Domain.Entities;
using MotoFindrAPI.Domain.Interfaces;

namespace MotoFindrAPI.Application.Services
{
    public class MotoApplicationService : IMotoApplicationService
    {
        private readonly IMotoRepository _motoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly IMotoqueiroRepository _motoqueiroRepository
        public MotoApplicationService(IMotoRepository motoRepository, IVagaRepository vagaRepository, IMotoqueiroRepository motoqueiroRepository)
        {
            _motoRepository = motoRepository;
            _vagaRepository = vagaRepository;
            _motoqueiroRepository = motoqueiroRepository;
        }
        public Task<MotoEntity> SalvarAsync(MotoDTO dto)
        {

        }
        public Task<bool> AtualizarMotoAsync(int id, MotoEntity moto)
        {
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
        private MotoEntity MapToEntity(MotoDTO dto)
        {
            var motoqueiro = _motoqueir

            var moto = new MotoEntity();
            MotoEntity motoEntity = new MotoEntity();
            motoEntity.Id = dto.Id;
            motoEntity.ModeloMoto = dto.ModeloMoto;
            motoEntity.AnoMoto = dto.AnoMoto;
            motoEntity.CorMoto = dto.CorMoto;
            

        }
    }
}
