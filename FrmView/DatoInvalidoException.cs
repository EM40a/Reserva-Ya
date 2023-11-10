using System.Runtime.Serialization;

namespace FrmView
{
    /// <summary>
    /// Excepcion que se produce cuando se ingresa un dato invalido
    /// </summary>
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