using Entidades.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmView
{
    /// <summary>
    /// Manejador de mensajes de <see cref="MessageBox"/> para formularios a travez de <see cref="DelegadoAlertar"/>
    /// </summary>
    internal class ManejadorDeMensajes
    {
        /// <summary>
        /// Delegado que muestra un mensaje en un <see cref="MessageBox"/> 
        /// </summary>
        public delegate DialogResult DelegadoAlertar(string? mensaje);

        internal static DialogResult MensajeNormal(string? mensaje)
        {
            return MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static DialogResult MensajeAdvertencia(string? mensaje)
        {
            return MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        internal static DialogResult MensajeError(string? mensaje)
        {
            return MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ManejarExcepcion(object sender, ExcepcionEventArgs e)
        {
            MensajeError(e.Excepcion.Message);
        }
    }
}
