namespace AtencionMedica.Domain.QueryFilters
{
    public class MedicoQueryFilter
    {
        public int? IdUsuario { get; set; }
        public string? RutDv { get; set; }
        public bool? EsActivo { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
