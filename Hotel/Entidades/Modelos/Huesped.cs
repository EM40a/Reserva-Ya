namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa un huesped del hotel
    /// </summary>
    public sealed class Huesped
    {
        #region Propiedades
        public int Id { get; set; } // PK
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public int IdReserva { get; set; } // FK
        #endregion

        /// <summary>
        /// Devuelve un string con los datos del huesped
        /// </summary>
        public override string ToString()
        {
            return $"{Apellido}, {Nombre} ({Id})\nNumero de reserva: {IdReserva}";
        }

        /// <summary>
        /// Un <see cref="Huesped"/> sera igual a una <see cref="Reserva"/> si el Id de la reserva
        /// coincide con el numero de reserva del huesped
        /// </summary>
        public static bool operator ==(Huesped h, Reserva r) => h.IdReserva == r.Id;
        
        /// <summary>
        /// Un <see cref="Huesped"/> sera distinto a una <see cref="Reserva"/> si el Id de la reserva
        /// es distinta al numero de reserva del huesped
        /// </summary>
        public static bool operator !=(Huesped h, Reserva r) => !(h == r);
    }
}