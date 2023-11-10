using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DataBase
{
    /// <summary>
    /// Interfaz que implementa los metodos para el manejo de la base de datos
    /// </summary>
    /// <typeparam name="T">Debe ser un registro y contar con un constructor público sin parámetros. </typeparam>
    /// 
    internal interface ComandosDB<T>
        where T : Registro
    {
        /// <summary>
        /// Obtiene todos los registros de la base de datos
        /// </summary>
        /// <returns>Una lista con todos los registros</returns>
        public List<T> ObtenerTodos();

        /// <summary>
        /// Agrega un registro a la base de datos
        /// </summary>
        /// <returns>Un entero con el id del registro agregado</returns>
        public int AgregarRegistro(T registro);

        /// <summary>
        /// Elimina un registro de la base datos
        /// </summary>
        /// <param name="id">El parametro por el cual elimina</param>
        /// <returns>True si lo logro eliminar, De lo contrario lanzara una excepcion</returns>
        public bool EliminarRegistro(int id);

        /// <summary>
        /// Modifica un registro de la base de datos
        /// </summary>
        /// <param name="registro">El registro a modificar</param>
        /// <returns>True si lo logro modificar, De lo contrario lanzara una excepcion</returns>
        public bool ModificarRegistro(T registro);
    }
}
