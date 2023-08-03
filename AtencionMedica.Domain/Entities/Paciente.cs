namespace AtencionMedica.Domain.Entities
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }
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
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual IEnumerable<FichaClinica> FichaClinicas { get; set; }
        public virtual IEnumerable<PacienteAdultoMayor> PacienteAdultoMayors { get; set; }
        public virtual IEnumerable<PacienteDiabetico> PacienteDiabeticos { get; set; }
        public virtual IEnumerable<PatologiaPaciente> PatologiaPacientes { get; set; }
        public virtual IEnumerable<ComplicacionPaciente> ComplicacionPacientes { get; set; }
        public virtual IEnumerable<HistorialClinico> HistorialClinicos { get; set; }
        
    }
}
