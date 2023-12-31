﻿using Entidades.Modelos;

namespace Entidades.BaseDeDatos
{
    /// <summary>
    /// Interfaz que implementa los metodos para el manejo de la base de datos
    /// </summary>
    /// <typeparam name="T">Debe ser un registro y contar con un constructor público sin parámetros. </typeparam>
    /// 
    internal interface IComandosDb
    {
        /// <summary>
        /// Agrega un registro a la base de datos
        /// </summary>
        /// <returns>Un entero con el id del registro agregado</returns>
        public void AgregarRegistro<T>(T registro) where T : class, new ();

        /// <summary>
        /// Obtiene un registro de la base de datos
        /// </summary>
        /// <typeparam name="T">Es el registro obtenido</typeparam>
        /// <typeparam name="U">Es la propidad a filtrar</typeparam>
        /// <param name="propiedad"></param>
        /// <returns></returns>
        public T SeleccionarRegistro<T>(int id) where T : class, new();


        /// <summary>
        /// Modifica un registro de la base de datos
        /// </summary>
        /// <param name="registro">El registro a modificar</param>
        /// <returns>True si lo logro modificar, De lo contrario lanzara una excepcion</returns>
        public bool ActualizarRegistro<T>(int id, int columnIndex, object nuevoValor) where T : class, new();

        /// <summary>
        /// Elimina un registro de la base datos
        /// </summary>
        /// <param name="id">El parametro por el cual elimina</param>
        /// <returns>True si lo logro eliminar, De lo contrario lanzara una excepcion</returns>
        public T? EliminarRegistro<T>(int id) where T : class, new();

        /// <summary>
        /// Obtiene todos los registros de la base de datos
        /// </summary>
        /// <returns>Una lista con todos los registros</returns>
        public List<T> SeleccionarTodos<T>() where T : class, new();
    }
}
