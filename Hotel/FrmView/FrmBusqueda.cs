using Entidades.Archivos;
using Entidades.BaseDeDatos;
using Entidades.Eventos;
using Entidades.Excepciones;
using Entidades.Modelos;
using System.Data;
using System.Reflection;
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
            
            CargarDatos();
        }
        #endregion

        #region Eventos
        private void ManejarExcepcion_ExcepcionOcurre(object sender, ExcepcionEventArgs e)
        {
            mostrar = new(MensajeError);
            mostrar(e.Excepcion.Message);
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
                    List<Huesped> huespedes = ImportarDatos<Huesped>();
                    
                    if (huespedes is not null)
                    {
                        gdb.AgregarRegistro(huespedes);
                    }
                }
                else if (rdbReservas.Checked)
                {
                    List<Reserva> reservas = ImportarDatos<Reserva>();
                    
                    if (reservas is not null)
                    {
                        gdb.AgregarRegistro(reservas);
                    }
                }

                mostrar = new(MensajeNormal);
                mostrar("Datos importados correctamente");
                CargarDatos();
            }
            catch (ArchivoInvalidoException ex)
            {
                manejarExcepcion.LanzarExcepcion(ex);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text;
            List<object> registros = new();

            if (int.TryParse(filtro, out int id))
            {
                if (rdbHuespedes.Checked)
                {
                    registros.Add(gdb.SeleccionarRegistro<Huesped>(id));
                }
                else
                {
                    registros.Add(gdb.SeleccionarRegistro<Reserva>(id));
                }

                dgvHotel.DataSource = registros;
            }
            else
            {
                CargarDatos();
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
                    CargarDatos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO
            mostrar = new(MensajeNormal);
            gdb.ActualizarRegistro<Huesped>(CapturarIdRegistro());
            mostrar("Registro actualizado...");
        }
        #endregion

        #region Metodos
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
        /// Llena un <see cref="DataGridView"/> con los datos de los registros 
        /// de <see cref="Reserva"/> o <see cref="Huesped"/> segun el tipo seleccionado
        /// </summary>
        private void MostrarDatos()
        {
            if (rdbHuespedes.Checked)
            {
                dgvHotel.DataSource = huespedes;
            }

            if (rdbReservas.Checked)
            {
                dgvHotel.DataSource = reservas;
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
                    return (int) celdaId.Value;
                }
            }

            return -1;
        }
        #endregion
    }
}
