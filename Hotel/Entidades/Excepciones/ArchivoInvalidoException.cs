using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando se encuentra un error manejando archivos
    /// </summary>
    [Serializable]
    public class ArchivoInvalidoException : Exception
    {
        public ArchivoInvalidoException()
        {
        }

        public ArchivoInvalidoException(string? message) : base(message)
        {
        }

        public ArchivoInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArchivoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}