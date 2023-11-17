using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class FechaInvalidaException : DatoInvalidoException
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
    }
}