using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Entidades.DataBase
{
    /// <summary>
    /// Clase que representa el gestor de la base de datos
    /// </summary>
    public class GestorSQL : DbContext
    {
        /// <summary>
        /// Representa la tabla de reservas
        /// </summary>
        public DbSet<Reserva> Reservas { get; set; }
        /// <summary>
        /// Representa la tabla de huespedes
        /// </summary>
        public DbSet<Huesped> Huespedes { get; set; }

        #region Metodos
        public int AgregarRegistro<T>(T registro) 
            where T : Registro
        {
            Add(registro);
            SaveChanges();
            return registro.Id;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;" +
                "Database=Hotel;" + // Cambiar por el nombre de la base de datos
                "Trusted_Connection=True;" +
                "TrustServerCertificate=Yes"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Para que el enum se guarde como string
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva> ()
                .Property(e => e.FormaDePago)
                .HasConversion(
                    v => v.ToString(),
                    v => (EFormaDePago) Enum.Parse(typeof(EFormaDePago), v)
                    );
        }
    }
}
