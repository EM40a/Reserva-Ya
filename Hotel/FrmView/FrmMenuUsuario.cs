using Entidades;
using System.Windows.Forms;

namespace FrmView
{
    public partial class FrmMenuUsuario : Form
    {
        #region Form
        public FrmMenuUsuario()
        {
            InitializeComponent();
        }

        private void FrmMenuUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Cierra la aplicacion
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Abre el formulario de registro de reservas
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            new FrmRegistroReservas().ShowDialog();
        }

        /// <summary>
        /// Abre el formulario de busqueda de reservas
        /// </summary>
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            new FrmBusqueda().ShowDialog();
        }
        #endregion

        /// <summary>
        /// Inicia el reloj
        /// </summary>
        private void InciarReloj()
        {
            while (true)
            {
                ActualizarVistaReloj();
                Thread.Sleep(1000);
            }

        }

        public delegate void Callback();

        /// <summary>
        /// Actualiza la vista del reloj
        /// </summary>
        private void ActualizarVistaReloj()
        {
            // Verifica si el hilo que llama es el hilo principal
            if (InvokeRequired)
            {
                Callback callback = new(ActualizarVistaReloj);
                // Llama al principal desde el hilo secundario
                BeginInvoke(ActualizarVistaReloj);
            }
            else
            {
            }
        }

        private void FrmMenuUsuario_Load(object sender, EventArgs e)
        {
        }

    }
}
