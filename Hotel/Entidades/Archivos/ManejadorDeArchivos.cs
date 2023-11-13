using Entidades.Excepciones;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades.Archivos
{
    /// <summary>
    /// Clase que se encarga de guardar y leer archivos
    /// </summary>
    public class ManejadorDeArchivos<T> 
        where T : class, new()
    {
        private static string directorio;

        static ManejadorDeArchivos()
        {
            // Establece el directorio en el escritorio
            directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Hotel\\";
            ValidarExistenciaDirectorio();
        }

        /// <summary>
        /// Valida que exista el directorio, si no existe lo crea
        /// </summary>
        private static void ValidarExistenciaDirectorio()
        {
            if (!Directory.Exists(directorio))
            {
                try
                {
                    Directory.CreateDirectory(directorio);
                }
                catch (IOException)
                {
                    throw new ArchivoInvalidoException("Error al crear el directorio");
                }
            }
        }

        /// <summary>
        /// Guarda un archivo en el directorio del proyecto
        /// </summary>
        public void GuardarArchivo(string nombreArchivo, T elemento)
        {
            string extension = Path.GetExtension(nombreArchivo).TrimStart('.');

            switch (extension.ToLower())
            {
                case "json":
                    SerializarJson(nombreArchivo, elemento);
                    break;

                case "xml":
                    SerializarXml(nombreArchivo, elemento);
                    break;

                default:
                    throw new ArchivoInvalidoException("Extensión no permitida");
            }
        }

        /// <summary>
        /// Serializa un objeto a JSON
        /// </summary>
        private void SerializarJson(string nombreArchivo, T elemento)
        {
            try
            {
                JsonSerializerOptions opciones = new();
                opciones.WriteIndented = true;

                using (StreamWriter writer = new(directorio + nombreArchivo))
                {
                    string strJson = JsonSerializer.Serialize(elemento, opciones);
                    //File.WriteAllText(directorio + nombreArchivo, strJson);
                }
            }
            catch(IOException)
            {
                throw new ArchivoInvalidoException("Error al guardar el archivo JSON");
            }
        }

        private void SerializarXml(string nombreArchivo, T elemento)
        {
            try
            {
                using StreamWriter writer = new(directorio + nombreArchivo);
                XmlSerializer xmlSerializer = new(typeof(T));
                xmlSerializer.Serialize(writer, elemento);
            }
            catch(IOException)
            {
                throw new ArchivoInvalidoException("Error al guardar el archivo XML");
            }
        }
    }
}

