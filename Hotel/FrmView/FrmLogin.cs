using Entidades.BaseDeDatos;
using Entidades.Eventos;
using Entidades.Excepciones;
using Entidades.Modelos;
using static FrmView.ManejadorDeMensajes;

namespace FrmView
{
    public partial class FrmLogin : Form
    {
        private ManejarExcepcion manejadorExcepciones;
        private string key;

        #region Form
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            key = "Admin";
            manejadorExcepciones = new ManejarExcepcion();
            manejadorExcepciones.ExcepcionOcurre += ManejarExcepcion;
        }
        #endregion

        #region Eventos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DatosCorrectos())
                {
                    Hide();
                    FrmMenuUsuario frmMenu = new ();
                    frmMenu.Show();
                }
            }
            catch (DatoInvalidoException ex)
            {
                manejadorExcepciones.LanzarExcepcion(ex);
            }
        }

        private void ManejarExcepcion(object sender, ExcepcionEventArgs e)
        {
            new DelegadoAlertar(MensajeError)(e.Excepcion.Message);
        }
        #endregion

        /// <summary>
        /// Valida que los datos ingresados sean correctos
        /// </summary>
        /// <returns>True si los datos coinciden, de lo contrario laza una excepcion</returns>
        /// <exception cref="DatoInvalidoException">Se produce tanto si la clave como el usuario son incorrectos</exception>
        private bool DatosCorrectos()
        {
            bool usuarioValido = txtUsuario.Text == key;
            bool claveValida = txtClave.Text == key;

            if (!usuarioValido)
            {
                throw new DatoInvalidoException("Usuario incorrecto");
            }
            else if (!claveValida)
            {
                throw new DatoInvalidoException("Clave incorrecta");
            }

            return true;
        }
    }
}
