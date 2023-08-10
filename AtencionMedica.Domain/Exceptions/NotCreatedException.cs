namespace AtencionMedica.Domain.Exceptions
{
    public class NotCreatedException : Exception
    {
        public NotCreatedException()
        {
                
        }

        public NotCreatedException(string mensaje) : base(mensaje)
        {
                
        }
    }
}
