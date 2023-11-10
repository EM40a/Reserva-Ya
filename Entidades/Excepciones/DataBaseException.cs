using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando ocurre un error en la base de datos
    /// </summary>
    [Serializable]
    public class DataBaseException : Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string? message) 
            : base(message)
        {
        }

        public DataBaseException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected DataBaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}