﻿namespace AtencionMedica.Domain.Entities
{
    [Table("PacienteAdultoMayor")]
    public class PacienteAdultoMayor : BaseEntity
    {
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public bool AutoValente { get; set; }
        public bool Dependencia { get; set; }
        public virtual Paciente? Paciente { get; set; }
    }
}
