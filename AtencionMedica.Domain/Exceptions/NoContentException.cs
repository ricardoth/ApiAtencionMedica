namespace AtencionMedica.Domain.Exceptions
{
    public class NoContentException : Exception
    {
        public NoContentException() { }

        public NoContentException(string mensaje) : base(mensaje)
        {
        }

    }
}
