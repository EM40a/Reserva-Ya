using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa un nodo de una lista enlazada
    /// </summary>
    public class Nodo<T> where T : class
    {
        /// <summary>
        /// Representa el elemento del nodo
        /// </summary>
        internal T? Elemento { get; set; }
        
        /// <summary>
        /// Representa el siguiente nodo de la lista
        /// </summary>
        internal Nodo<T>? SiguienteNodo { get; set; }
    }
}
