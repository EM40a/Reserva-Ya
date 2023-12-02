using Entidades.Archivos;
using Entidades.BaseDeDatos;
using Entidades.Eventos;
using Entidades.Excepciones;
using Entidades.Modelos;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using static FrmView.ManejadorDeMensajes;

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
        private ManejarExcepcion manejarExcepcion;
        private DelegadoAlertar mostrar;

        #region Form    
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            gdb = new();

            manejarExcepcion = new();
            manejarExcepcion.ExcepcionOcurre += ManejarExcepcion_ExcepcionOcurre;

            ofdImportar.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml|Archivos CSV (*.csv)|*.csv";
            sfdExportar.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml|Archivos CSV (*.csv)|*.csv";
            Task.Run(ActualizarGrilla);
        }
        #endregion

        #region Eventos
        private void ManejarExcepcion_ExcepcionOcurre(object sender, ExcepcionEventArgs e)
        {
            mostrar = new(MensajeError);
            mostrar(e.Excepcion.Message);
        }

        // Rellena la grilla segun el tipo de registro seleccionado
        private void rdbReservas_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
        private void rdbHuespedes_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbHuespedes.Checked)
                {
                    ExportarDatos(huespedes);
                }
                else if (rdbReservas.Checked)
                {
                    ExportarDatos(reservas);
                }
            }
            catch (ArchivoInvalidoException ex)
            {
                manejarExcepcion.LanzarExcepcion(ex);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbHuespedes.Checked)
                {
                    List<Huesped> nuevosHuespedes = ImportarDatos<Huesped>();

                    if (nuevosHuespedes is not null)
                    {
                        gdb.AgregarRegistro(nuevosHuespedes);
                    }
                }
                else if (rdbReservas.Checked)
                {
                    List<Reserva> nuevasReservas = ImportarDatos<Reserva>();
                    if (nuevasReservas is not null)
                    {
                        gdb.AgregarRegistro(nuevasReservas);
                    }
                }
            }
            catch (Exception ex)
            {
                manejarExcepcion.LanzarExcepcion(ex);
            }
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
            mostrar = new(MensajeAdvertencia);
            DialogResult dialogResult = mostrar("¿Seguro que deseas eliminar el registro?");

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Elimina el registro de la base de datos y actualiza la grilla
                    if (rdbHuespedes.Checked)
                    {
                        Huesped? huesped = gdb.EliminarRegistro<Huesped>(CapturarIdRegistro());
                        gdb.EliminarRegistro<Reserva>(huesped.IdReserva);
                    }
                    else
                    {
                        gdb.EliminarRegistro<Reserva>(CapturarIdRegistro());
                    }
                }
                catch (BaseDeDatosException ex)
                {
                    manejarExcepcion.LanzarExcepcion(ex);
                }
                finally
                {
                    ActualizarGrilla();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgvHotel.ReadOnly = false;
        }

        private void dgvHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvHotel.Columns[e.ColumnIndex].ReadOnly == false)
            {
                // Habilita la edición de la celda seleccionada
                dgvHotel.BeginEdit(true);

                object nuevoValor = dgvHotel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                ActualizarRegistro(e.ColumnIndex, nuevoValor);
            }
        }

        private void dgvHotel_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                manejarExcepcion.LanzarExcepcion(new("Formato incorrecto"));
            }

            // Cancela la propagación de la excepción
            e.Cancel = true;
        }
        #endregion

        #region Metodos
        private void ActualizarRegistro(int columnIndex, object nuevoValor)
        {
            try
            {
                int id = CapturarIdRegistro();

                if (rdbHuespedes.Checked)
                {
                    gdb.ActualizarRegistro<Huesped>(id, columnIndex, nuevoValor);
                }
                else
                {
                    gdb.ActualizarRegistro<Reserva>(id, columnIndex, nuevoValor);
                }
            }
            catch (BaseDeDatosException ex)
            {
                manejarExcepcion.LanzarExcepcion(ex);
            }
        }

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
        /// Llena un <see cref="DataGridView"/> con los datos de los registros 
        /// de <see cref="Reserva"/> o <see cref="Huesped"/> segun el tipo seleccionado 
        /// previamente consultando a la base de datos
        /// </summary>
        private void ActualizarGrilla()
        {
            CargarDatos();

            if (rdbHuespedes.Checked)
            {
                dgvHotel.DataSource = huespedes;
            }

            else if (rdbReservas.Checked)
            {
                dgvHotel.DataSource = reservas;
            }
        }

        /// <summary>
        /// Carga los datos de las tablas al manejador de contexto <see cref="HotelContext"/> 
        /// </summary>
        private void CargarDatos()
        {
            // Si requiere invocar el hilo principal
            if (InvokeRequired)
            {
                BeginInvoke(ActualizarGrilla);
            }
            else
            {
                reservas = gdb.Reservas.ToList();
                huespedes = gdb.Huespedes.ToList();
            }
        }

        /// <summary>
        /// Exporta los datos de la grilla a un archivo de texto en la ruta seleccionada a traves
        /// del <see cref="ManejadorDeArchivos{T}"/>
        /// </summary>
        /// <param name="registros">Una lista con los objetos a agregar</param>
        /// <exception cref="ExtensionNoPermitidaException"></exception>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private void ExportarDatos<T>(List<T> registros) where T : class, new()
        {
            try
            {
                ManejadorDeArchivos<T> manejadorDeArchivos = new();
                sfdExportar.FileName = $"Data-{typeof(T).Name}"; // Le da un nombre por defecto al archivo

                if (sfdExportar.ShowDialog() == DialogResult.OK)
                {
                    mostrar = new(MensajeNormal);
                    manejadorDeArchivos.ExportarArchivo(sfdExportar.FileName, registros);
                    mostrar("Datos exportados exitosamente");
                }
            }
            catch (ArgumentException)
            {
                throw new ArchivoInvalidoException("Nombre de archivo invalido");
            }
            catch (ArchivoInvalidoException)
            {
                throw;
            }
        }

        /// <summary>
        /// Importa los datos de un archivo de texto a la base de datos a traves del <see cref="ManejadorDeArchivos{T}"/>
        /// </summary>
        /// <typeparam name="T">El tipo de registro a importar</typeparam>
        /// <returns></returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private List<T>? ImportarDatos<T>() where T : class, new()
        {
            try
            {
                ManejadorDeArchivos<T> manejadorDeArchivos = new();

                if (ofdImportar.ShowDialog() == DialogResult.OK)
                {
                    mostrar = new(MensajeNormal);
                    mostrar("Datos importados correctamente");
                    ActualizarGrilla();
                    return manejadorDeArchivos.ImportarArchivo<T>(ofdImportar.FileName);
                }

                return null;
            }
            catch (ArgumentException)
            {
                throw new ArchivoInvalidoException();
            }
            catch (ArchivoInvalidoException)
            {
                throw;
            }
        }

        /// <summary>
        /// Captura el id del registro seleccionado en la <see cref="DataGridView"/>
        /// </summary>
        /// <returns>El Id del registro seleccionado o -1 en caso de error</returns>
        private int CapturarIdRegistro()
        {
            // Si hay una celda seleccionada
            if (dgvHotel.SelectedCells.Count > 0)
            {
                // Captura el id del registro seleccionado
                DataGridViewRow filaSeleccionada = dgvHotel.Rows[dgvHotel.SelectedCells[0].RowIndex];
                DataGridViewCell celdaId = filaSeleccionada.Cells["Id"];

                if (celdaId is not null && celdaId.Value is not null)
                {
                    return (int)celdaId.Value;
                }
            }

            return -1;
        }
        #endregion
    }
}
