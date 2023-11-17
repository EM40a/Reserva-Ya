using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    public class DirectorioNoEncontradoException : ArchivoInvalidoException
    {
        public DirectorioNoEncontradoException()
        {
        }

        public DirectorioNoEncontradoException(string? message) : base(message)
        {
        }
    }
}