namespace AtencionMedica.Domain.Entities
{
    [Table("Paciente")]
    public class Paciente : BaseEntity
    {
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Sexo { get; set; }
        public virtual ICollection<FichaClinica> FichaClinicas { get; set; }
        public virtual ICollection<PacienteAdultoMayor> PacienteAdultoMayors { get; set; }
        public virtual ICollection<PacienteDiabetico> PacienteDiabeticos { get; set; }
        public virtual ICollection<PatologiaPaciente> PatologiaPacientes { get; set; }
        public virtual ICollection<ComplicacionPaciente> ComplicacionPacientes { get; set; }
        public virtual ICollection<HistorialClinico> HistorialClinicos { get; set; }
        
    }
}
