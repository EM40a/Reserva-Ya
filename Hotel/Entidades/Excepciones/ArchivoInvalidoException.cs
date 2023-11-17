using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Excepcion que se lanza cuando se encuentra un error manejando archivos
    /// </summary>
    [Serializable]
    public class ArchivoInvalidoException : Exception
    {
        public ArchivoInvalidoException() : this("Error al importar el archivo")
        {
        }

        public ArchivoInvalidoException(string? message) : base(message)
        {
        }

        public ArchivoInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}