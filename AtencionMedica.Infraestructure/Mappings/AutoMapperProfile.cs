
namespace AtencionMedica.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patologia, PatologiaDto>()
                .ForMember(des => des.IdPatologia, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
