using Entidades;
using Entidades.BaseDeDatos;
using Entidades.DataBase;
using System.Windows.Forms;

namespace FrmView
{
    public partial class FrmMenuUsuario : Form
    {
        private HotelContext gdb;

        #region Form
        public FrmMenuUsuario()
        {
            InitializeComponent();
        }

        private void FrmMenuUsuario_Load(object sender, EventArgs e)
        {
            gdb = new();
            gdb.CrearDataBase();
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
    }
}
