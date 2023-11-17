using Entidades.Excepciones;
using System.Text;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa una reserva de un cliente
    /// </summary>
    /// 
    public class Reserva
    {
        /// <summary>
        /// Enumerado de las formas de pago admitidas de la/s <see cref="Reserva"/>/s
        /// </summary>
        public enum EFormaDePago
        {
            Efectivo = 0,
            Debito = 6,
            Credito = 10
        }

        private DateTime _fechaEntrada;
        private DateTime _fechaSalida;
        private EFormaDePago _formaDePago;

        public Reserva()
        {
            _fechaEntrada = DateTime.Now;
            _fechaSalida = DateTime.Now.AddDays(1);
            _formaDePago = EFormaDePago.Efectivo;
        }

        #region Propiedades
        public int Id { get; set; }

        public DateTime FechaEntrada
        {
            get => _fechaEntrada;
            set => SetFechaEntrada(value);
        }
        public DateTime FechaSalida
        {
            get => _fechaSalida;
            set => SetFechaSalida(value);
        }

        public string FormaDePago
        {
            get => _formaDePago.ToString();
            set => _formaDePago = (EFormaDePago) Enum.Parse(typeof(EFormaDePago), value);
        }

        public int Valor { get; set; }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que la <see cref="FechaEntrada"/> sea valida
        /// </summary>
        /// <exception cref="FechaInvalidaException"></exception>
        private void SetFechaEntrada(DateTime fechaEntrada)
        {
            if (fechaEntrada > fechaEntrada.AddYears(1))
            {
                throw new FechaInvalidaException("La fecha de entrada no puede ser posterior a un año");
            }

            _fechaEntrada = fechaEntrada;
        }

        /// <summary>
        /// Verifica que <see cref="FechaSalida"/> sea valida
        /// </summary>
        /// <exception cref="FechaInvalidaException"></exception>
        private void SetFechaSalida(DateTime fechaSalida)
        {
            if (fechaSalida <= _fechaEntrada)
            {
                throw new FechaInvalidaException("La fecha de salida no puede ser anterior a la fecha de entrada");
            }

            _fechaSalida = fechaSalida;
        }
        #endregion

        /// <summary>
        /// Devuelve un <see cref="string"/> con los datos de la reserva
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Numero {Id}:");
            sb.Append(_fechaEntrada.ToString("M"));
            sb.Append(" - ");
            sb.AppendLine(_fechaSalida.ToString("M"));
            sb.Append($"Valor: $");
            sb.Append(Valor);
            sb.Append($" USD ({FormaDePago})");
            return sb.ToString();
        }

        /// <summary>
        /// Una <see cref="Reserva"/> sera igual a un <see cref="Huesped"/> si el Id de la reserva 
        /// coincide con el Id de la reserva del huesped
        /// </summary>
        public static bool operator ==(Reserva r, Huesped h) => r.Id == h.IdReserva;

        /// <summary>
        /// Una <see cref="Reserva"/> sera distinta a un <see cref="Huesped"/> si el Id de la reserva 
        /// no coincide con el Id de la reserva del huesped
        /// </summary>
        public static bool operator !=(Reserva r, Huesped h) => !(r == h);
    }
}
