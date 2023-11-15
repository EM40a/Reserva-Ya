using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmView
{
    /// <summary>
    /// Delegado que muestra un mensaje en un <see cref="MessageBox"/> 
    /// </summary>
    public delegate void DAlertar(string? mensaje);

    /// <summary>
    /// Manejador de mensajes de <see cref="MessageBox"/> para formularios
    /// </summary>
    internal class MessageBoxHelper
    {
        internal static void MensajeNormal(string? mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void MensajeAdvertencia(string? mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void MensajeError(string? mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
