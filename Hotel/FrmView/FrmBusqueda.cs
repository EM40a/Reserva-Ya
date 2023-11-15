using Entidades.Archivos;
using Entidades.BaseDeDatos;
using Entidades.Excepciones;
using Entidades.Modelos;
using System.Data;
using static FrmView.MessageBoxHelper;

namespace FrmView
{
    /// <summary>
    /// Formulario que permite buscar y exportar los datos de la base de datos
    /// </summary>
    public partial class FrmBusqueda : Form
    {
        private HotelContext gdb;
        private List<Reserva> reservas;
        private List<Huesped> huespedes;

        #region Form    
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            gdb = new();
            CargarDatos();
        }
        #endregion

        #region Eventos
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbReservas.Checked)
                {
                    ExportarDatos(reservas);
                }
                else if (rdbHuespedes.Checked)
                {
                    ExportarDatos(huespedes);
                }
                new DAlertar(MensajeNormal)("Datos exportados exitosamente");
            }
            catch (ArchivoInvalidoException except)
            {
                new DAlertar(MensajeError)(except.Message);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbReservas.Checked)
                {
                    ImportarDatos<Reserva>();
                }
                else
                {
                    ImportarDatos<Huesped>();
                }

                CargarDatos();
                new DAlertar(MensajeNormal)("Datos exportados correctamente");

            }
            catch (ArchivoInvalidoException except)
            {
                new DAlertar(MensajeError)(except.Message);
            }
        }

        private void rdbReservas_CheckedChanged(object sender, EventArgs e)
        {
            // Rellena la grilla segun el tipo de registro seleccionado
            CargarDatos();
        }

        private void rdbHuespedes_CheckedChanged(object sender, EventArgs e)
        {
            // Rellena la grilla segun el tipo de registro seleccionado
            CargarDatos();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.ToLower();

            // Realiza la búsqueda y filtra la lista de datos
            if (rdbReservas.Checked)
            {
                dgvHotel.DataSource = RealizarBusqueda(reservas, filtro);
            }
            else
            {
                dgvHotel.DataSource = RealizarBusqueda(huespedes, filtro);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Realiza la búsqueda de los datos en la lista según el filtro recibido por parametro
        /// </summary>
        /// <typeparam name="T">El registro de la lista</typeparam>
        /// <returns>La lista filtrada</returns>
        private List<T> RealizarBusqueda<T>(List<T> datos, string filtro)
        {
            return datos
                // Por cada elemento obtiene sus propiedades
                .Where(e => e.GetType().GetProperties()
                // Chequea que el valor de la propiedad contenga el filtro o devuelva false
                .Any(p => p.GetValue(e)?.ToString().ToLower().Contains(filtro) ?? false))
                .ToList(); // Convierte el resultado a una lista
        }

        /// <summary>
        /// Exporta los datos de la grilla a un archivo de texto en la ruta seleccionada a traves
        /// del <see cref="ManejadorDeArchivos{T}"/>
        /// </summary>
        /// <param name="registros">Una lista con los objetos a agregar</param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private void ExportarDatos<T>(List<T> registros) where T : class, new()
        {
            ManejadorDeArchivos<T> manejadorDeArchivos = new();
            sfdExportar.FileName = $"Data-{typeof(T).Name}"; // Le da un nombre por defecto al archivo

            if (sfdExportar.ShowDialog() == DialogResult.OK)
            {
                manejadorDeArchivos.ExportarArchivo(sfdExportar.FileName, registros);
            }

            throw new ArchivoInvalidoException("Operación cancelada");
        }

        /// <summary>
        /// Importa los datos de un archivo de texto a la base de datos a traves del <see cref="ManejadorDeArchivos{T}"/>
        /// </summary>
        /// <typeparam name="T">El tipo de registro a importar</typeparam>
        /// <returns></returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private List<T>? ImportarDatos<T>() where T : class, new()
        {
            ManejadorDeArchivos<T> manejadorDeArchivos = new();

            if (ofdImportar.ShowDialog() == DialogResult.OK)
            {
                return manejadorDeArchivos.ImportarArchivo<T>(ofdImportar.FileName);
            }

            throw new ArchivoInvalidoException("Operación cancelada");
        }

        /// <summary>
        /// Llena un <see cref="DataGridView"/> con los datos de los registros 
        /// de <see cref="Reserva"/> o <see cref="Huesped"/> segun el tipo seleccionado"/>
        /// </summary>
        private void MostrarDatos()
        {
            if (rdbReservas.Checked)
            {
                dgvHotel.DataSource = reservas;
            }

            if (rdbHuespedes.Checked)
            {
                dgvHotel.DataSource = huespedes;
            }
        }

        /// <summary>
        /// Carga los datos de las tablas al manejador de contexto <see cref="HotelContext"/> 
        /// y muestra los datos en el <see cref="DataGridView"/>
        /// </summary>
        private void CargarDatos()
        {
            reservas = gdb.Reservas.ToList();
            huespedes = gdb.Huespedes.ToList();
            MostrarDatos();
        }
        #endregion
    }
}
