using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando se intenta agregar/modificar/eliminar/obtener un registro inválido.
    /// </summary>
    [Serializable]
    public class RegistroInvalidoException : Exception
    {
        public RegistroInvalidoException()
        {
        }

        public RegistroInvalidoException(string? message) : base(message)
        {
        }

        public RegistroInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RegistroInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}