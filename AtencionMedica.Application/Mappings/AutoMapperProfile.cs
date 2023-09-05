namespace AtencionMedica.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Mantenedores Base
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

            CreateMap<Medico, MedicoDto>()
                .ForMember(des => des.IdMedico, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Modulo, ModuloDto>()
               .ForMember(des => des.IdModulo, opt => opt.MapFrom(src => src.Id))
               .ReverseMap()
               .ForMember(c => c.LugarAtencion, u => u.Ignore());

            CreateMap<Modulo, ModuloGetDto>()
                .ForMember(des => des.IdModulo, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            #endregion

            #region Pacientes
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

            CreateMap<PacienteAdultoMayor, PacienteAdultoMayorDto>()
                .ForMember(des => des.IdPacienteAdultoMayor, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PacienteAdultoMayor, PacienteAdultoMayorGetDto>()
                .ForMember(des => des.IdPacienteAdultoMayor, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(p => p.Paciente, u => u.Ignore());

            CreateMap<PacienteDiabetico, PacienteDiabeticoDto>()
                .ForMember(des => des.IdPacienteDiabetico, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PacienteDiabetico, PacienteDiabeticoGetDto>()
                .ForMember(des => des.IdPacienteDiabetico, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(p => p.Paciente, u => u.Ignore());
            #endregion

            #region Relaciones
            CreateMap<LugarAtencion, LugarAtencionDto>()
               .ForMember(des => des.IdLugarAtencion, opt => opt.MapFrom(src => src.Id))
               .ReverseMap()
               .ForMember(c => c.Comuna, u => u.Ignore());

            CreateMap<LugarAtencion, LugarAtencionGetDto>()
                .ForMember(des => des.IdLugarAtencion, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<EspecialidadMedico, EspecialidadMedicoDto>()
              .ForMember(des => des.IdEspecialidadMedico, opt => opt.MapFrom(src => src.Id))
              .ReverseMap()
              .ForMember(c => c.Especialidad, u => u.Ignore())
              .ForMember(c => c.Medico, u => u.Ignore());

            CreateMap<EspecialidadMedico, EspecialidadMedicoGetDto>()
                .ForMember(des => des.IdEspecialidadMedico, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<FichaClinicaDetalle, FichaClinicaDetalleDto>()
              .ForMember(des => des.IdFichaClinicaDetalle, opt => opt.MapFrom(src => src.Id))
              .ReverseMap()
              .ForMember(c => c.FichaClinica, u => u.Ignore());

            CreateMap<FichaClinicaDetalle, FichaClinicaDetalleGetDto>()
                .ForMember(des => des.IdFichaClinicaDetalle, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<FichaClinica, FichaClinicaDto>()
             .ForMember(des => des.IdFichaClinica, opt => opt.MapFrom(src => src.Id))
             .ReverseMap()
             .ForMember(c => c.Paciente, u => u.Ignore())
             .ForMember(c => c.EstadoFichaClinica, u => u.Ignore())
             .ForMember(c => c.Personal, u => u.Ignore())
             .ForMember(c => c.Modulo, u => u.Ignore())
             .ForMember(c => c.Medico, u => u.Ignore());

            CreateMap<FichaClinica, FichaClinicaGetDto>()
                .ForMember(des => des.IdFichaClinica, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<HistorialClinico, HistorialClinicoDto>()
             .ForMember(des => des.IdHistorialClinico, opt => opt.MapFrom(src => src.Id))
             .ReverseMap()
             .ForMember(c => c.Paciente, u => u.Ignore());

            CreateMap<HistorialClinico, HistorialClinicoGetDto>()
                .ForMember(des => des.IdHistorialClinico, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<PatologiaPaciente, PatologiaPacienteDto>()
             .ForMember(des => des.IdPatologiaPaciente, opt => opt.MapFrom(src => src.Id))
             .ReverseMap()
             .ForMember(c => c.Paciente, u => u.Ignore())
             .ForMember(c => c.Patologia, u => u.Ignore());

            CreateMap<PatologiaPaciente, PatologiaPacienteGetDto>()
                .ForMember(des => des.IdPatologiaPaciente, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<RecetaMedica, RecetaMedicaDto>()
             .ForMember(des => des.IdRecetaMedica, opt => opt.MapFrom(src => src.Id))
             .ReverseMap()
             .ForMember(c => c.HistorialClinico, u => u.Ignore())
             .ForMember(c => c.Medicamento, u => u.Ignore());

            CreateMap<RecetaMedica, RecetaMedicaGetDto>()
                .ForMember(des => des.IdRecetaMedica, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            #endregion
        }
    }
}
