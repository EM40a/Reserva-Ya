using Entidades.Excepciones;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa un <see cref="Huesped"/> del hotel
    /// </summary>
    public sealed class Huesped
    {
        private DateTime _fechaDeNacimiento;

        #region Propiedades
        public int Id { get; set; } // PK
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento
        {
            get => _fechaDeNacimiento;
            set => SetFechaDeNacimiento(value);
        }
        public string Telefono { get; set; }
        public int IdReserva { get; set; } // FK
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el <see cref="Huesped"/> sea mayor de edad
        /// </summary>
        /// <param name="fechaDeNacimiento">La fecha a validar</param>
        /// <exception cref="DatoInvalidoException"></exception>
        private void SetFechaDeNacimiento(DateTime fechaDeNacimiento)
        {
            if (!EsMayorDeEdad(fechaDeNacimiento))
            {
                throw new DatoInvalidoException("Debe ser mayor de edad para hacer una reserva");
            }

            _fechaDeNacimiento = fechaDeNacimiento;
        }

        public static bool EsMayorDeEdad(DateTime fechaDeNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaDeNacimiento.Year;

            if (fechaDeNacimiento.Month > fechaActual.Month && fechaDeNacimiento.Day > fechaActual.Day)
            {
                edad--;
            }

            return edad >= 18;
        }
        #endregion

        #region Sobrecargas
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
        #endregion
    }
}