﻿namespace AtencionMedica.Domain.Entities
{
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        [ConcurrencyCheck]
        public DateTime? FecActualizacion { get; set; }
    }
}
