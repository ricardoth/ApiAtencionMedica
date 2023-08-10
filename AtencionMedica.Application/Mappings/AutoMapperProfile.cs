﻿namespace AtencionMedica.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patologia, PatologiaDto>()
                .ForMember(des => des.IdPatologia, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Complicacion, ComplicacionDto>()
                .ForMember(des => des.IdComplicacion, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Especialidad, EspecialidadDto>()
                .ForMember(des => des.IdEspecialidad, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
