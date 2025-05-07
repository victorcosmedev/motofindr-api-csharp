using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
        private readonly IMotoqueiroRepository _motoqueiroRepository;
        private readonly IMapper _mapper;
        public MotoApplicationService(
            IMotoRepository motoRepository,
            IVagaRepository vagaRepository,
            IMotoqueiroRepository motoqueiroRepository,
            IMapper mapper
        )
        {
            _motoRepository = motoRepository;
            _vagaRepository = vagaRepository;
            _motoqueiroRepository = motoqueiroRepository;
            _mapper = mapper;
        }
        public async Task<MotoEntity> SalvarAsync(MotoDTO dto)
        {
            MotoEntity entity = _mapper.Map<MotoEntity>(dto);
            try
            {
                entity = await AtribuirVaga(entity);
                entity = await AtribuirMotoqueiro(entity);

                return await _motoRepository.SalvarAsync(entity);    
            }
            catch (Exception ex)
            {
                throw;
            }
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
            var motoqueiro = moto.Motoqueiro;
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
            var moto = new MotoEntity();
            MotoEntity motoEntity = new MotoEntity();
            motoEntity.Id = dto.Id;
            motoEntity.NomeMoto = dto.NomeMoto;
            motoEntity.ModeloMoto = dto.ModeloMoto;
            motoEntity.AnoMoto = dto.AnoMoto;
            motoEntity.CorMoto = dto.CorMoto;
            motoEntity.MotoqueiroId = dto.MotoqueiroId;
            motoEntity.Motoqueiro = null;
            motoEntity.VagaId = dto.VagaId;
            motoEntity.Vaga = null;

            return motoEntity;
        }
        private async Task<MotoEntity> AtribuirVaga(MotoEntity moto)
        {
            if (moto.VagaId == null)
                throw new Exception("Esta vaga não existe");

            var vaga = await _vagaRepository.BuscarPorIdAsync((int)moto.VagaId);
            if (vaga == null)
                throw new Exception("Esta vaga não existe");

            if (moto.Id != vaga.MotoId)
                throw new Exception("Esta vaga já está ocupada por outra moto");
            moto.Vaga = vaga;
            return moto;
        }
        private async Task<MotoEntity> AtribuirMotoqueiro(MotoEntity moto)
        {
            if (moto.MotoqueiroId != null)
            {
                var motoqueiro = await _motoqueiroRepository.BuscarPorIdAsync((int)moto.MotoqueiroId);
                if(motoqueiro != null && motoqueiro.MotoId != moto.Id)
                {
                    throw new Exception("Este motoqueiro já tem outra moto associada a ele.");
                }

                moto.Motoqueiro = motoqueiro;
            }
            return moto;
        }
    }
}
