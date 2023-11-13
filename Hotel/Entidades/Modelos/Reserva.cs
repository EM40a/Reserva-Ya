using Entidades.Excepciones;
using System.Text;
using static Entidades.Modelos.Reserva;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa una reserva de un cliente
    /// </summary>
    /// 
    public class Reserva
    {
        /// <summary>
        /// Enumerado de las formas de pago admitidas
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
            _fechaEntrada = DateTime.Today;
            _fechaSalida = DateTime.Today.AddDays(1);
            _formaDePago = EFormaDePago.Efectivo;
        }

        #region Propiedades
        public int Id { get; set; }

        public string FechaEntrada
        {
            get => _fechaEntrada.ToString();
            set => SetFechaEntrada(value);
        }
        public string FechaSalida
        {
            get => _fechaSalida.ToString();
            set => SetFechaSalida(value);
        }

        public string FormaDePago
        {
            get => _formaDePago.ToString();
            set => _formaDePago = (EFormaDePago) Enum.Parse(typeof(EFormaDePago), value);
        }

        public int Valor { get; set; } = 50;
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que la fecha de salida sea valida
        /// </summary>
        private void SetFechaSalida(string strFechaSalida)
        {
            if (!DateTime.TryParse(strFechaSalida, out DateTime fechaSalida))
            {
                throw new DatoInvalidoException("La fecha no cuenta con el formato correcto");
            }

            if (fechaSalida <= DateTime.Today)
            {
                throw new DatoInvalidoException("La reserva debe tener al menos un dia");
            }
            else if (fechaSalida > _fechaEntrada.AddMonths(1))
            {
                throw new DatoInvalidoException("La reserva no puede ser mayor a un mes");
            }

            _fechaSalida = fechaSalida;
        }
        
        /// <summary>
        /// Verifica que la fecha de entrada sea valida
        /// </summary>
        public void SetFechaEntrada(string strFechaEntrada)
        {
            if (!DateTime.TryParse(strFechaEntrada, out DateTime fechaEntrada))
            {
                throw new DatoInvalidoException("La fecha no cuenta con el formato correcto");
            }

            if (fechaEntrada < DateTime.Today)
            {
                throw new DatoInvalidoException("La reserva debe tener al menos un dia");
            }
            if (fechaEntrada > DateTime.Today.AddYears(1))
            {
                throw new DatoInvalidoException("El plazo maximo de reserva es de un año");
            }
            _fechaEntrada = fechaEntrada;
        }
        #endregion

        /// <summary>
        /// Devuelve un string con los datos de la reserva
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
        /// Una reserva sera igual a un huesped si el id de la reserva coincide con el id de la reserva del huesped
        /// </summary>
        /// <returns>True si ambos id son iguales, False si no lo son</returns>
        public static bool operator ==(Reserva r, Huesped h) => r.Id == h.IdReserva;

        /// <summary>
        /// Una reserva sera distinta a un huesped si el id de la reserva no coincide con el id de la reserva del huesped
        /// </summary>
        /// <returns>False si ambos id son iguales, True si no lo son</returns>
        public static bool operator !=(Reserva r, Huesped h) => !(r == h);
    }
}
