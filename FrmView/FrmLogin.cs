using Entidades.Modelos;

namespace FrmView
{
    public partial class FrmLogin : Form
    {
        private FrmMenuUsuario frmMenuUsuario;
        private const string key = "Admin";

        public FrmLogin()
        {
            InitializeComponent();
            frmMenuUsuario = new();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
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
                FrmRegistroReservas.MostrarError(except);
            }
        }
        
        /// <summary>
        /// Valida que los datos ingresados sean correctos
        /// </summary>
        /// <returns>True si los datos coinciden, de lo contrario laza una excepcion</returns>
        /// <exception cref="DatoInvalidoException">Se produce tanto si la clave como el usuario son incorrectos</exception>
        private bool DatosCorrectos()
        {
            if (txtUsuario.Text != key && txtClave.Text != key)
            {
                throw new DatoInvalidoException("Dato incorrecto");
            }

            return true;
        }
    }
}
