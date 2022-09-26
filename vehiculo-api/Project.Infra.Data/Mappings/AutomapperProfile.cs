using AutoMapper;
using Project.Domain.Dtos;
using Project.Domain.Entities;

namespace Project.Infra.Data.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Vehiculo, VehiculoDto>()
                .ForMember(d => d.CombustibleName, o => o.MapFrom(x => x.IdCombustibleNavigation.Name))
                .ForMember(d => d.TipoVehiculoName, o => o.MapFrom(x => x.IdTipoVehiculoNavigation.Name))
                .ForMember(d => d.MarcaName, o => o.MapFrom(x => x.IdMarcaNavigation.Name))
                .ForMember(d => d.TransmisionName, o => o.MapFrom(x => x.IdTransmisionNavigation.Name));

            CreateMap<VehiculoDto, Vehiculo>();

            CreateMap<Combustible, CombustibleDto>();
            CreateMap<CombustibleDto, Combustible>();

            CreateMap<Marca, MarcaDto>();
            CreateMap<MarcaDto, Marca>();

            CreateMap<TipoVehiculo, TipoVehiculoDto>();
            CreateMap<TipoVehiculoDto, TipoVehiculo>();

            CreateMap<Transmision, TransmisionDto>();
            CreateMap<TransmisionDto, Transmision>();
        }
    }
}
