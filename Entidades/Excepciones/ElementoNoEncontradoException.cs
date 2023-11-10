using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando no se encuentra un elemento
    /// </summary>
    [Serializable]
    internal class ElementoNoEncontradoException : Exception
    {
        public ElementoNoEncontradoException()
        {
        }

        public ElementoNoEncontradoException(string? message)
            : base(message)
        {
        }

        public ElementoNoEncontradoException(string? message, Exception? innerException) 
            : base(message, innerException)
        {
        }

        protected ElementoNoEncontradoException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}