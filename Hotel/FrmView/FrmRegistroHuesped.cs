using Entidades.BaseDeDatos;
using Entidades.Eventos;
using Entidades.Excepciones;
using Entidades.Modelos;
using static FrmView.ManejadorDeMensajes;

namespace FrmView
{
    /// <summary>
    /// Formulario que permite registrar un <see cref="Huesped"/> en la base de datos
    /// </summary>
    public partial class FrmRegistroHuesped : Form
    {
        private HotelContext gdb;
        private Huesped huesped;
        private Reserva ReservaAsociada { get; set; }
        private ManejarExcepcion manejar;
        private DelegadoAlertar mostrar;

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
            // Inicializa los campos
            gdb = new();
            manejar = new();
            huesped = new();
            // Suscribe el manejador de excepciones
            manejar.ExcepcionOcurre += Manejar_ExcepcionOcurre;
            // Muestra el id de la reserva
            lblIdReserva.Text = ReservaAsociada.Id.ToString();
        }

        private void FrmRegistroHuesped_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReservaAsociada != huesped)
            {
                mostrar = new(MensajeAdvertencia);
                DialogResult dialogResult = mostrar("Se cancelará la reserva. ¿Desea salir?");
                
                if (dialogResult == DialogResult.Yes)
                {
                    gdb.EliminarRegistro<Reserva>(ReservaAsociada.Id);
                }
                else if(dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Maneja el evento <see cref="ManejarExcepcion.ExcepcionOcurre"/> y muestra un <see cref="MensajeError(string?)"/>
        /// </summary>
        private void Manejar_ExcepcionOcurre(object? sender, ExcepcionEventArgs e)
        {
            mostrar = new(MensajeError);
            mostrar(e.Excepcion.Message);
        }

        /// <summary>
        /// Guarda el huesped en la base de datos y muestra un <see cref="MensajeNormal(string?)"/>
        /// o <see cref="MensajeError(string?)"/> respectivamente a travez de <see cref="DelegadoAlertar"/>
        /// </summary>
        /// <exception cref="BaseDeDatosException"></exception>
        /// <exception cref="DatoInvalidoException"></exception>"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Genera el huesped y lo agrega a la db
                huesped = GenerarHuesped();
                gdb.AgregarRegistro(huesped);

                // Muestra el mensaje y limpiar el form
                new DelegadoAlertar(MensajeNormal)("Registro exitoso");
                LimpiarCampos();
                Close();
            }
            catch (Exception ex)
            {
                manejar.LanzarExcepcion(ex);
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
                return new()
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
