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
            try
            {
                var entity = _mapper.Map<MotoEntity>(dto);
                entity.Vaga = await AtribuirVaga(entity);
                entity.Motoqueiro = await AtribuirMotoqueiro(entity);

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

        private async Task<VagaEntity?> AtribuirVaga(MotoEntity moto)
        {
            if (moto.VagaId == null)
                return null;

            var vaga = await _vagaRepository.BuscarPorIdAsync((int)moto.VagaId);
            if (vaga == null)
                throw new Exception("Esta vaga não existe");

            if (moto.Id != vaga.MotoId)
                throw new Exception("Esta vaga já está ocupada por outra moto");

            return vaga;
        }
        private async Task<MotoqueiroEntity?> AtribuirMotoqueiro(MotoEntity moto)
        {
            if (moto.MotoqueiroId != null)
            {
                var motoqueiro = await _motoqueiroRepository.BuscarPorIdAsync((int)moto.MotoqueiroId);
                if(motoqueiro != null && motoqueiro.MotoId != moto.Id)
                {
                    throw new Exception("Este motoqueiro já tem outra moto associada a ele.");
                }
                return motoqueiro;
            }
            return null;
        }
    }
}
