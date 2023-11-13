using Entidades.BaseDeDatos;
using Entidades.Modelos;
using Entidades.Excepciones;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using static FrmView.MessageBoxHelper;
using static Entidades.Modelos.Reserva;
using System.ComponentModel;

namespace FrmView
{
    public partial class FrmRegistroReservas : Form
    {
        private HotelContext gdb;

        #region Form
        public FrmRegistroReservas()
        {
            InitializeComponent();
        }

        private void FrmRegistroReservas_Load(object sender, EventArgs e)
        {
            gdb = new();
            cmbFormaPago.DataSource = Enum.GetValues(typeof(EFormaDePago));
            ControlarFechas();
        }
        #endregion

        #region Eventos
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
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MostrarMensaje delegado = new(MensajeNormal);

            try
            {
                Reserva reserva = GenerarReserva();
                gdb.AgregarRegistro(reserva);

                delegado(reserva.ToString());

                FrmRegistroUsuario frmRegistroUsuario = new(reserva); 
                frmRegistroUsuario.Show();
                Hide();
            }
            catch (Exception except)
            {
                delegado = new(MensajeError);
                delegado(except.Message);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera una reserva con los datos ingresados
        /// </summary>
        private Reserva GenerarReserva()
        {
            try
            {
                Reserva reserva = new()
                {
                    FechaEntrada = dtpCheckIn.Value.ToString(),
                    FechaSalida = dtpCheckOut.Value.ToString(),
                    FormaDePago = cmbFormaPago.SelectedItem.ToString(),
                    Valor = CalcularValor(dtpCheckIn.Value, dtpCheckOut.Value, (EFormaDePago) cmbFormaPago.SelectedItem)
                };
                return reserva;
            }
            catch (DatoInvalidoException)
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula el valor de la reservas segun los dias de estadia y la forma de pago
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

            valor = dias * 50;
            valor += valor * (int)formaDePago / 100;

            if (valor > 0)
            {
                lblCalcularValor.Text = "$" + valor + " USD";
            }
            return valor;
        }

        /// <summary>
        /// Controla que las fechas sean validas
        /// </summary>
        private void ControlarFechas()
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);

            dtpCheckIn.MaxDate = DateTime.Today.AddYears(1);
        }
        #endregion
    }
}
