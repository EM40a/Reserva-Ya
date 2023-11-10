using System.Net;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa un huesped del hotel
    /// </summary>
    public class Huesped : Registro
    {
        /// <summary>
        /// Representa el nombre del huesped
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Representa el apellido del huesped
        /// </summary>
        public string Apellido { get; set; }
        /// <summary>
        /// Representa la fecha de nacimiento del huesped
        /// </summary>
        public DateTime FechaDeNacimiento { get; set; }
        /// <summary>
        /// Representa el numero de telefono del huesped
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Representa el numero de la reserva del huesped
        /// </summary>
        public int IdReserva { get; set; }

        /// <summary>
        /// Devuelve un string con los datos del huesped
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + $"{Apellido}, {Nombre}\nReserva:{IdReserva}";
        }
    }
}