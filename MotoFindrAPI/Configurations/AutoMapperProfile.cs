using AutoMapper;
using MotoFindrAPI.Application.DTOs;
using MotoFindrAPI.Domain.Entities;
namespace MotoFindrAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MotoDTO, MotoEntity>()
                .ForMember(dest => dest.Motoqueiro, opt => opt.Ignore())
                .ForMember(dest => dest.Vaga, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<VagaDTO, VagaEntity>()
                .ForMember(dest => dest.Moto, opt => opt.Ignore())
                .ForMember(dest => dest.Secao, opt => opt.Ignore())
                .ForMember(dest => dest.Disponivel, opt => opt.Ignore());
        }
    }
}
