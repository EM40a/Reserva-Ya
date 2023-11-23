using Entidades.BaseDeDatos;
using Entidades.Modelos;
using Entidades.Excepciones;
using static FrmView.ManejadorDeMensajes;
using static Entidades.Modelos.Reserva;
using Entidades.Eventos;

namespace FrmView
{
    /// <summary>
    /// Formulario que permite registrar una <see cref="Reserva"/> en la base de datos
    /// con el manejador de contexto <see cref="HotelContext"/>
    /// </summary>
    public partial class FrmRegistroReservas : Form
    {
        private ManejarExcepcion manejadorExcepciones;
        private HotelContext gdb;

        #region Form
        public FrmRegistroReservas()
        {
            InitializeComponent();
        }

        private void FrmRegistroReservas_Load(object sender, EventArgs e)
        {
            gdb = new();
            manejadorExcepciones = new();
            manejadorExcepciones.ExcepcionOcurre += ManejarExcepcion;
            cmbFormaPago.DataSource = Enum.GetValues(typeof(EFormaDePago));
            ControlarFechas();
        }
        #endregion

        #region Eventos
        private void ManejarExcepcion(object sender, ExcepcionEventArgs e)
        {
            new DelegadoAlertar(MensajeError)(e.Excepcion.Message);
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            CalcularValor(dtpCheckIn.Value, dtpCheckOut.Value, (EFormaDePago)cmbFormaPago.SelectedItem);
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            CalcularValor(dtpCheckIn.Value, dtpCheckOut.Value, (EFormaDePago)cmbFormaPago.SelectedItem);
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor(dtpCheckIn.Value, dtpCheckOut.Value, (EFormaDePago)cmbFormaPago.SelectedItem);
        }

        /// <summary>
        /// Guarda la reserva en la base de datos
        /// </summary>
        /// <exception cref="DatoInvalidoException"></exception>
        /// <exception cref="BaseDeDatosException"></exception>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                // Genera la reserva y la agrega a la db
                Reserva reserva = GenerarReserva();
                gdb.AgregarRegistro(reserva);

                // Muestra la reserva 
                new DelegadoAlertar(MensajeNormal)("Reserva generada exitosamente");

                // Abre el formulario de registro de huesped y cierra el actual
                Close();

                FrmRegistroHuesped frmRegistroUsuario = new(reserva);
                frmRegistroUsuario.ShowDialog();
            }
            catch (Exception ex)
            {
                manejadorExcepciones.LanzarExcepcion(ex);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera una <see cref="Reserva"/> con los datos ingresados en el formulario
        /// </summary>
        /// <exception cref="DatoInvalidoException"></exception>
        private Reserva GenerarReserva()
        {
            try
            {
                return new Reserva()
                {
                    FechaEntrada = dtpCheckIn.Value.Date,
                    FechaSalida = dtpCheckOut.Value.Date,
                    FormaDePago = cmbFormaPago.SelectedItem.ToString(),
                    Valor = CalcularValor(dtpCheckIn.Value, dtpCheckOut.Value, (EFormaDePago) cmbFormaPago.SelectedItem)
                };
            }
            catch (DatoInvalidoException)
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula el valor de la <see cref="Reserva"/> segun los dias de estadia y la <see cref="EFormaDePago"/>
        /// </summary>
        private int CalcularValor(DateTime fechaEntrada, DateTime fechaSalida, EFormaDePago formaDePago)
        {
            int dias = -1;
            int valor;

            while (fechaEntrada <= fechaSalida)
            {
                dias++;
                fechaEntrada = fechaEntrada.AddDays(1);
            }

            // 50 USD por dia
            valor = dias * 50; 
            valor += valor * (int) formaDePago / 100;

            if (valor > 0)
            {
                lblCalcularValor.Text = "$" + valor + " USD";
            }
            return valor;
        }

        /// <summary>
        /// Controla los limites de los <see cref="DateTimePicker"/> para que 
        /// las fechas de entrada y salida sean validas
        /// </summary>
        private void ControlarFechas()
        {
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
            dtpCheckIn.MinDate = DateTime.Now;
            dtpCheckOut.MinDate = DateTime.Now.AddDays(1);
            dtpCheckIn.MaxDate = DateTime.Now.AddYears(1);
        }
        #endregion
    }
}
