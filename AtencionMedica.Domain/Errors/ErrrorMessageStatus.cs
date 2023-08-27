namespace AtencionMedica.Domain.Errors
{
    public static class ErrrorMessageStatus
    {
        public static readonly string NoRecordsFound = "No se encontraron registros en la BD.";
        public static readonly string CreateFailed = "No se pudo crear el registro.";
        public static readonly string ReadFailed = "No se pudo leer el registro.";
        public static readonly string NotFound = "El registro solicitado no se encontró.";
        public static readonly string UpdateFailed = "No se pudo actualizar el registro.";
        public static readonly string DeleteFailed = "No se pudo eliminar el registro.";
    }
}
