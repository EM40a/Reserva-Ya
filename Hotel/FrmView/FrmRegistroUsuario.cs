using Entidades.BaseDeDatos;
using Entidades.Excepciones;
using Entidades.Modelos;
using static FrmView.MessageBoxHelper;

namespace FrmView
{
    /// <summary>
    /// Formulario que permite registrar un <see cref="Huesped"/> en la base de datos
    /// </summary>
    public partial class FrmRegistroHuesped : Form
    {
        private HotelContext gdb;
        private Reserva ReservaAsociada { get; set; }

        #region Form
        public FrmRegistroHuesped()
        {
            InitializeComponent();
        }
        public FrmRegistroHuesped(Reserva reserva) : this()
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
        /// Guarda el huesped en la base de datos y muestra un <see cref="MensajeNormal(string?)"/>
        /// o <see cref="MensajeError(string?)"/> respectivamente a travez de <see cref="DAlertar"/>
        /// </summary>
        /// <exception cref="RegistroInvalidoException"></exception>
        /// <exception cref="DatoInvalidoException"></exception>"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Genera el huesped y lo agrega a la db
                Huesped huesped = GenerarHuesped();
                gdb.AgregarRegistro(huesped);

                // Muestra el mensaje y limpiar el form
                new DAlertar(MensajeNormal)("Registro exitoso");
                LimpiarCampos();
                Hide();
            }
            catch (Exception except)
            {
                new DAlertar(MensajeError)(except.Message);
            }
        }

        /// <summary>
        /// Genera un <see cref="Huesped"/> con los datos ingresados en el formulario y lo retorna
        /// </summary>
        /// <exception cref="DatoInvalidoException"></exception>
        private Huesped GenerarHuesped()
        {
            try
            {
                return new Huesped()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    FechaDeNacimiento = dtpFechaDeNacimiento.Value,
                    IdReserva = ReservaAsociada.Id,
                    Telefono = txtTelefono.Text
                };
            }
            catch (DatoInvalidoException)
            {
                throw;
            }
        }

        /// <summary>
        /// Limpia los campos del formulario, tanto los <see cref="TextBox"/>
        /// como los <see cref="DateTimePicker"/> y <see cref="Label"/>
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            lblIdReserva.Text = string.Empty;
            dtpFechaDeNacimiento.ResetText();
        }
        #endregion
    }
}
