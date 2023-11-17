using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos
{
    /// <summary>
    /// Clase que maneja <see cref="Exception"/>
    /// </summary>
    public class ManejarExcepcion
    {
        public event EventHandler<ExcepcionEventArgs> ExcepcionOcurre;

        /// <summary>
        /// Método para lanzar el evento con la excepcion
        /// </summary>
        public void LanzarExcepcion(Exception ex)
        {
            OnExcepcionOcurre(new ExcepcionEventArgs 
                { 
                    Excepcion = ex 
                });
        }

        /// <summary>
        /// Método para invocar el evento 
        /// </summary>
        protected virtual void OnExcepcionOcurre(ExcepcionEventArgs e)
        {
            if (e is not null)
            {
                ExcepcionOcurre?.Invoke(this, e);
            }
        }
    }
}
