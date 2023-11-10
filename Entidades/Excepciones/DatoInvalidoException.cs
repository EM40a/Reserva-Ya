using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    [Serializable]
    internal class DatoInvalidoException : Exception
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