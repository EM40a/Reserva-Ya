using Entidades.Archivos;
using Entidades.BaseDeDatos;
using Entidades.Excepciones;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FrmView.MessageBoxHelper;
namespace FrmView
{
    public partial class FrmBusqueda : Form
    {
        private HotelContext gdb;
        private List<Reserva> reservas;

        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            gdb = new();
            reservas = gdb.Reservas.ToList();
            LlenarGrilla(reservas);
        }

        private void LlenarGrilla(List<Reserva>? datos)
        {
            if (datos != null)
            {
                dtgHotel.Rows.Clear();

                foreach (Reserva r in datos)
                {
                    dtgHotel.Rows.Add(r.Id, r.FechaEntrada, r.FechaSalida, r.FormaDePago, r.Valor);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MostrarMensaje delegado = new(MensajeNormal);
            try
            {
                ManejadorDeArchivos<Reserva> manejadorDeArchivos = new();

                foreach (Reserva reserva in reservas)
                {
                    manejadorDeArchivos.GuardarArchivo("reservas." + cmbExtension.SelectedItem, reserva);
                }
                delegado("Se exportaron las reservas");
            }
            catch (ArchivoInvalidoException except)
            {
                delegado = new(MensajeError);
                delegado(except.Message);
            }
        }
    }
}
