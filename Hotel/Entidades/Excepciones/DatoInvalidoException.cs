using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando un dato es invalido o nulo
    /// </summary>
    public class DatoInvalidoException : Exception
    {
        public DatoInvalidoException()
        {
        }

        public DatoInvalidoException(string? message) : base(message)
        {
        }

        public DatoInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}