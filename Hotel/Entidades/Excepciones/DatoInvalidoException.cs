using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando se intenta crear un objeto con un dato inválido.
    /// </summary>
    [Serializable]
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

        protected DatoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}