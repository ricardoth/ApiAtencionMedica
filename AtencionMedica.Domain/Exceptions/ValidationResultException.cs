namespace AtencionMedica.Domain.Exceptions
{
    public class ValidationResultException : Exception
    {
        public List<string> Errors { get; }

        public ValidationResultException(List<string> errors) : base ($"Hubo Errores de Validación: {string.Join(", ", errors)}")
        {
            Errors = errors;        
        }
    }
}
