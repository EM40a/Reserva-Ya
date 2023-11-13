using Entidades.BaseDeDatos;
using Entidades.Excepciones;
using Entidades.Modelos;
using System;
using static FrmView.MessageBoxHelper;


namespace FrmView
{
    public partial class FrmRegistroUsuario : Form
    {
        private HotelContext gdb;
        private Reserva ReservaAsociada { get; set; }

        #region Form
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }
        public FrmRegistroUsuario(Reserva reserva) : this()
        {
            ReservaAsociada = reserva;
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            gdb = new();
            lblIdReserva.Text = ReservaAsociada.Id.ToString();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Guarda el huesped en la base de datos
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MostrarMensaje delegado = new(MensajeNormal);

            try
            {
                Huesped huesped = GenerarHuesped();
                gdb.AgregarRegistro(huesped);

                delegado(huesped.ToString());
            }
            catch (Exception except)
            {
                delegado = new(MensajeError);
                delegado(except.Message);
            }
        }

        /// <summary>
        /// Genera un huesped con los datos ingresados en el formulario
        /// </summary>
        private Huesped GenerarHuesped()
        {
            try
            {
                Huesped huesped = new()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaDeNacimiento = dtpFechaDeNacimiento.Value,
                    IdReserva = ReservaAsociada.Id
                };

                huesped.SetTelefono(txtTelefono.Text);
                return huesped;
            }
            catch (DatoInvalidoException)
            {
                throw;
            }
        }
        #endregion
    }
}
