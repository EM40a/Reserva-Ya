using Entidades.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DataBase
{
    public static class ComandosExtended
    {
        /// <summary>
        /// Crea la base de datos si no existe
        /// </summary>
        public static bool CrearDataBase(this HotelContext gdb)
        {
            return gdb.Database.EnsureCreated();
        }
    }
}
