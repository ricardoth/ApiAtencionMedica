namespace AtencionMedica.Application.Mappings
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

            CreateMap<EstadoFichaClinica, EstadoFichaClinicaDto>()
                .ForMember(des => des.IdEstadoFichaClinica, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<EstadoAgendaMedico, EstadoAgendaMedicoDto>()
                .ForMember(des => des.IdEstadoFichaClinica, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Comuna, ComunaDto>()
                .ForMember(des => des.IdComuna, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Paciente, PacienteDto>()
                .ForMember(des => des.IdUsuario, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<ComplicacionPaciente, ComplicacionPacienteDto>()
                .ForMember(des => des.IdComplicacionPaciente, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(c => c.Complicacion, u => u.Ignore())
                .ForMember(p => p.Paciente, u => u.Ignore());

            CreateMap<ComplicacionPaciente, ComplicacionPacienteGetDto>()
                .ForMember(des => des.IdComplicacionPaciente, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
               
        }
    }
}
