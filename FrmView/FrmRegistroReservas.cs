using Entidades.DataBase;
using Entidades.Modelos;
using Entidades.Excepciones;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace FrmView
{
    public partial class FrmRegistroReservas : Form
    {
        private Reserva reserva;

        public FrmRegistroReservas()
        {
            InitializeComponent();
        }

        private void FrmRegistroReservas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Cierra la aplicacion
        }

        private void FrmRegistroReservas_Load(object sender, EventArgs e)
        {
            reserva = new Reserva();
            cmbFormaPago.DataSource = Enum.GetValues(typeof(EFormaDePago));
            ConfigurarFechas();
        }

        #region Eventos
        /// <summary>
        /// Actualiza la fecha de entrada de la reserva
        /// </summary>
        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            reserva.FechaEntrada = dtpCheckIn.Value;
            dtpCheckOut.MaxDate = dtpCheckIn.Value.AddMonths(1);
        }

        /// <summary>
        /// Actualiza la fecha de salida de la reserva
        /// </summary>
        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            reserva.FechaSalida = dtpCheckOut.Value;
        }

        /// <summary>
        /// Actualiza la forma de pago de la reserva
        /// </summary>
        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            reserva.FormaDePago = (EFormaDePago)cmbFormaPago.SelectedItem;
        }

        /// <summary>
        /// Calcula el valor de la reserva
        /// </summary>
        private void btnCalcularValor_Click(object sender, EventArgs e)
        {
            SetValor();
        }

        /// <summary>
        /// Guarda la reserva en la base de datos
        /// </summary>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SetValor();
            try
            {
                GestorSQL gdb = new();
                gdb.Reservas.Add(reserva);
                gdb.SaveChanges();
            }
            catch (SqlException except)
            {
                MostrarError(except);
            }
        }
        #endregion


        #region Validaciones
        public static void MostrarError(Exception mensaje)
        {
            MessageBox.Show(mensaje.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Inicializa y configura los limites de los time picker
        /// </summary>
        private void ConfigurarFechas()
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);

            dtpCheckIn.MaxDate = DateTime.Now.AddYears(1); // Hasta un año de anticipacion
            dtpCheckOut.MaxDate = dtpCheckIn.Value.AddMonths(1);
        }

        /// <summary>
        /// Calcula el valor de la reserva y lo asigna al label
        /// </summary>
        private void SetValor()
        {
            try
            {
                reserva.CalcularValor();
                lblCalcularValor.Text = $"${reserva.Valor}";
            }
            catch (DatoInvalidoException except)
            {
                MostrarError(except);
            }
        }
        #endregion
    }
}
