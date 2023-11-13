using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmView
{
    /// <summary>
    /// Delegado que muestra un mensaje
    /// </summary>
    public delegate void MostrarMensaje(string? mensaje);

    /// <summary>
    /// Clase que contiene metodos para mostrar mensajes
    /// </summary>
    internal class MessageBoxHelper
    {
        public static void MensajeNormal(string? mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MensajeAdvertencia(string? mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MensajeError(string? mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
