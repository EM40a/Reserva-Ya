using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
    [Serializable]
    public class ExtensionNoPermitidaException : ArchivoInvalidoException
    {
        public ExtensionNoPermitidaException() :base("Extension no permitida")
        {

        }
    }
}