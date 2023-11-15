using Entidades.Excepciones;
using Entidades.Modelos;
using static Entidades.Modelos.Reserva;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    public delegate void DelegadoDB();
    /// <summary>
    /// Clase que representa el gestor de la base de datos
    /// </summary>
    public class HotelContext : DbContext, IComandosDb 
    {
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Huesped> Huespedes { get; set; }

        #region Metodos
        /// <summary>
        /// Agrega un registro a la base de datos
        /// </summary>
        /// <typeparam name="T">Sera un tipo de registro (Reserva o Huesped)</typeparam>
        public void AgregarRegistro<T>(T registro) where T : class, new()
        {
            try
            {
                Add(registro);
                SaveChanges();
            }
            catch
            {
                throw new RegistroInvalidoException("No se pudo agregar el registro");
            }
        }

        public void AgregarRegistro<T>(List<T> registros) where T : class, new()
        {
            foreach (var registro in registros)
            {
                AgregarRegistro(registro);
            }
        }

        /// <summary>
        /// Elimina un registro de la base de datos
        /// </summary>
        /// <typeparam name="T">Sera un tipo de registro (Reserva o Huesped)</typeparam>
        /// <param name="id">El parametro por el que se elimina el registro</param>
        public bool EliminarRegistro<T>(int id) where T : class, new()
        {
            try
            {
                T? registro = Find<T>(id);
                Remove(registro);
                SaveChanges();
                return true;
            }
            catch(NullReferenceException)
            {
                throw new RegistroInvalidoException("El registro no existe en la base de datos");
            }
            catch(SqlException)
            {
                throw new RegistroInvalidoException("No se pudo eliminar el registro");
            }
        }

        public bool ModificarRegistro<T>(T registro) where T : class, new()
        {
            
            throw new NotImplementedException();
        }

        public List<T> Obtener<T, U>(U propiedad) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> ObtenerTodos<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conexion a la Base de Datos
            optionsBuilder.UseSqlServer(
                "Server=.;" +
                "Database=Hotel;" + // Cambiar por el nombre de la base de datos
                "Trusted_Connection=True;" +
                "TrustServerCertificate=Yes"
                );
        }
    }
}
