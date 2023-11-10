using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    /// <summary>
    /// Clase que representa una reserva de un cliente
    /// </summary>
    /// 
    public class Reserva : Registro
    {
        public Reserva()
        {
        }

        #region Propiedades
        /// <summary>
        /// Representa la fecha de entrada de la reserva
        /// </summary>
        public DateTime FechaEntrada { get; set; }
        
        /// <summary>
        /// Representa la fecha de salida de la reserva
        /// </summary>
        public DateTime FechaSalida { get; set; }

        /// <summary>
        /// Representa la forma de pago de la reserva
        /// </summary>
        public EFormaDePago FormaDePago { get; set; }
        #endregion

        /// <summary>
        /// Devuelve el valor de la reserva en dolares
        /// </summary>
        public int Valor { get; private set; }

        #region Metodos
        /// <summary>
        /// Calcula el valor de la reserva en dolares segun la cantidad de dias y la forma de pago
        /// </summary>
        public void CalcularValor()
        {
            TimeSpan duracion = FechaSalida - FechaEntrada;
            int valorBase = (int) duracion.TotalDays * 50; // 50 dolares por dia
            int aumento = valorBase * (int) FormaDePago / 100;
            int valorFinal = valorBase + aumento;
            
            if (valorFinal <= 0)
            {
                throw new DatoInvalidoException("La fecha de inicio no puede ser posterior a la fecha de fin");
            }

            Valor = valorBase + aumento;
        }
        #endregion

        /// <summary>
        /// Devuelve un string con los datos de la reserva
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{base.ToString()}: ");
            sb.Append(FechaEntrada.ToString("M"));
            sb.Append(" - ");
            sb.AppendLine(FechaSalida.ToString("M"));
            sb.Append($"Valor: $");
            sb.Append(Valor);
            sb.Append($"USD ({FormaDePago})");
            return sb.ToString();
        }
    }
}
