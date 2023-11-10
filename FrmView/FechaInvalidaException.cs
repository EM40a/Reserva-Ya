using System.Runtime.Serialization;

namespace FrmView
{
    [Serializable]
    internal class FechaInvalidaException : Exception
    {
        public FechaInvalidaException()
        {
        }

        public FechaInvalidaException(string? message) : base(message)
        {
        }

        public FechaInvalidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FechaInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}