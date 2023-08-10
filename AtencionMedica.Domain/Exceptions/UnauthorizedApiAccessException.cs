namespace AtencionMedica.Domain.Exceptions
{
    public class UnauthorizedApiAccessException : Exception
    {
        public UnauthorizedApiAccessException()
        {
            
        }

        public UnauthorizedApiAccessException(string mensaje) : base(mensaje)
        {
                
        }
    }
}
