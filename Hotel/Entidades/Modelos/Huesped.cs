using Entidades.Excepciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa un huesped del hotel
    /// </summary>
    public sealed class Huesped
    {
        private string _telefono;

        #region Propiedades
        public int Id { get; set; } // PK
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get => _telefono; set => SetTelefono(value); }
        public int IdReserva { get; set; } // FK
        #endregion

        public void SetTelefono(string telefono)
        {
            telefono = telefono.Trim();
            if (ValidarTelefono(telefono))
            {
                string primeraMitad = telefono.Substring(0, 4);
                string segundaMitad = telefono.Substring(4);
                _telefono = $"+54 9 11 {primeraMitad}-{segundaMitad}";
            }
            else
            {
                throw new DatoInvalidoException("El telefono debe tener 8 digitos");
            }
        }

        /// <summary>
        /// Valida que el telefono sea valido
        /// </summary>
        private bool ValidarTelefono(string telefono)
        {
            return telefono.All(char.IsDigit) && !string.IsNullOrEmpty(telefono) && telefono.Length == 8;
        }

        /// <summary>
        /// Devuelve un string con los datos del huesped
        /// </summary>
        public override string ToString()
        {
            return $"{Apellido}, {Nombre} ({Id})\nNumero de reserva: {IdReserva}";
        }

        public static bool operator ==(Huesped h, Reserva r) => h.IdReserva == r.Id;
        public static bool operator !=(Huesped h, Reserva r) => !(h == r);
    }
}