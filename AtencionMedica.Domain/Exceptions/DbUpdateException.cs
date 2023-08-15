using System.Data.Common;

namespace AtencionMedica.Domain.Exceptions
{
    public class DbUpdateException : DbException
    {
        public DbUpdateException() : base() {}

        public DbUpdateException(string mensaje) : base(mensaje)
        {
        }

        public DbUpdateException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
