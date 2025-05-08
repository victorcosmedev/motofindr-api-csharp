using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging.Abstractions;
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
        public async Task<bool> AtualizarMotoAsync(int id, MotoDTO dto)
        {
            try
            {
                var entity = _mapper.Map<MotoEntity>(dto);
                entity.Vaga = await AtribuirVaga(entity);
                entity.Motoqueiro = await AtribuirMotoqueiro(entity);

                return await _motoRepository.AtualizarAsync(id, entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<MotoDTO?> BuscarMotoPorIdAsync(int id)
        {
            var entity = await _motoRepository.BuscarPorIdAsync(id);
            if (entity == null)
                return null;

            var motoDTO = _mapper.Map<MotoDTO>(entity);
            return motoDTO;
        }
        public async Task<IEnumerable<MotoDTO>> BuscarTodasMotosPorPatioAsync()
        {
            var motos = await _motoRepository.BuscarTodasAsync();
            var motosDTO = motos.Select(x => _mapper.Map<MotoDTO>(x));
            return motosDTO;
        }
        public async Task<bool> DeletarMotoAsync(int id)
        {
            return await _motoRepository.DeletarAsync(id);
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
