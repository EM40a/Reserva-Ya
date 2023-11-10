namespace Entidades.Modelos
{
    /// <summary>
    /// Clase base para los registros de la base de datos
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// Representa el id del registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Devuelve un string con el id del registro
        /// </summary>
        public override string ToString()
        {
            return $"Nro {Id}";
        }
    }
}
