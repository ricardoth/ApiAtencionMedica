namespace AtencionMedica.Application.DTOs
{
    public class PacienteDto
    {
        public int? IdUsuario { get; set; }
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
    }
}
