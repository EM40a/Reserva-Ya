using Entidades.Excepciones;
using Entidades.Modelos;
using static Entidades.Modelos.Reserva;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Entidades.BaseDeDatos
{
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
                throw new BaseDeDatosException("No se pudo agregar el registro");
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
        /// <exception cref="ArgumentNullException"></exception>
        public T? EliminarRegistro<T>(int id) where T : class, new()
        {
            try
            {
                T? registro = SeleccionarRegistro<T>(id);
                Remove(registro);
                SaveChanges();
                return registro;
            }
            catch(ArgumentNullException)
            {
                throw new BaseDeDatosException($"No se encotro el/la {typeof(T).Name}");
            }
            catch(Exception)
            {
                throw new BaseDeDatosException($"No se pudo eliminar el/la {typeof(T).Name}");
            }
        }

        public bool ActualizarRegistro<T>(int id) where T : class, new()
        {
            try
            {
                T registro = SeleccionarRegistro<T>(id);
                Update(registro);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Error al actualizar el registro");
            }
        }

        /// <summary>
        /// Busca un registro por su Id en la base de datos, si lo encuentra lo retorna
        /// </summary>
        /// <typeparam name="T">El registro a buscar</typeparam>
        /// <exception cref="BaseDeDatosException"></exception>
        public T SeleccionarRegistro<T>(int id) where T : class, new()
        {
            try
            {
                return Find<T>(id);
            }
            catch(ArgumentNullException)
            {
                throw new BaseDeDatosException("El registro no existe en la base de datos");
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("Error al encontrar el registro");
            }
        }

        public List<T> SeleccionarTodos<T>() where T : class, new()
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
