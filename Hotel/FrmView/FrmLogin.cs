using Entidades.Excepciones;
using Entidades.Modelos;
using static FrmView.MessageBoxHelper;

namespace FrmView
{
    public partial class FrmLogin : Form
    {
        private string key;

        #region Form
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            key = "Admin";
        }
        #endregion

        #region Eventos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmMenuUsuario frmMenuUsuario = new();

            try
            {
                if (DatosCorrectos())
                {
                    this.Hide();
                    frmMenuUsuario.Show();
                }
            }
            catch (DatoInvalidoException except)
            {
                DAlertar delegado = new(MensajeError);
                delegado(except.Message);
            }
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


            if (!usuarioValido && !claveValida)
            {
                throw new DatoInvalidoException("Usuario o contraseña incorrecto/s");
            }
            else if (!usuarioValido)
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
