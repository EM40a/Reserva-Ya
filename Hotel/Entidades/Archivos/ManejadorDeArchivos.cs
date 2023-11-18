using System.Text.Json;
using System.Xml.Serialization;
using Entidades.Excepciones;

namespace Entidades.Archivos
{

    /// <summary>
    /// Clase que se encarga de guardar y leer archivos
    /// </summary>
    /// <typeparam name="T">Tipo de dato a guardar</typeparam>
    public class ManejadorDeArchivos<T>
        where T : class, new()
    {
        /// <summary>
        /// Guarda un archivo en el directorio del proyecto
        /// </summary>
        /// <param name="nombreArchivo">Es el nombre del archivo a guardar</param>
        /// <param name="elementos">El objeto a serializar</param>
        /// <exception cref="ExtensionNoPermitidaException"></exception>
        /// <exception cref="DirectorioNoEncontradoException"></exception>
        public void ExportarArchivo(string path, List<T> elementos)
        {
            try
            {
                // Verifica la extension del archivo
                string extension = Path.GetExtension(path.TrimStart('.'));

                switch (extension.TrimStart('.').ToLower())
                {
                    case "json":
                        SerializarJson(path, elementos);
                        break;

                    case "xml":
                        SerializarXml(path, elementos);
                        break;

                    default:
                        throw new ExtensionNoPermitidaException();
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectorioNoEncontradoException("Directorio no encontrado");
            }
            catch(Exception)
            {
                throw new ArchivoInvalidoException();
            }
        }

        /// <summary>
        /// Importa un archivo desde el directorio recibido por parametro segun la extencion del archivo (JSON o XML)/>
        /// </summary>
        /// <returns>Una <see cref="List{T}"/> con los elementos deserializados</returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        /// <exception cref="ExtensionNoPermitidaException"></exception>"
        public List<T>? ImportarArchivo<T>(string directorio)
        {
            try
            {
                string extension = Path.GetExtension(directorio.TrimStart('.'));

                switch (extension.TrimStart('.').ToLower())
                {
                    case "json":
                        return DeserializarJson<T>(directorio);

                    case "xml":
                        return DeserializarXml<T>(directorio);

                    default:
                        throw new ExtensionNoPermitidaException();
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectorioNoEncontradoException("Directorio no encontrado");
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serializa un objeto a JSON
        /// </summary>
        /// <param name="nombreArchivo">Es el nombre del archivo a guardar</param>
        /// <param name="elemento">El objeto a serializar</param>
        private void SerializarJson(string path, List<T> elemento)
        {
            JsonSerializerOptions opciones = new();
            opciones.WriteIndented = true;

            using (StreamWriter sw = new(path))
            {
                string strJson = JsonSerializer.Serialize(elemento, opciones);
                sw.WriteLine(strJson);
            }
        }

        /// <summary>
        /// Deserializa un archivo JSON con los datos del tipo de dato recibido por parametro
        /// </summary>
        /// <returns>Una <see cref="List{T}"/> con los elementos deserializados</returns>
        private List<T>? DeserializarJson<T>(string path)
        {
            using (StreamReader reader = new(path))
            {
                string strJson = reader.ReadToEnd();

                return JsonSerializer.Deserialize<List<T>>(strJson);
            }
        }

        /// <summary>
        /// Serializa un objeto a XML en la ruta especificada
        /// </summary>
        /// <param name="nombreArchivo">Es el nombre del archivo a guardar</param>
        /// <param name="elementos">El objeto a serializar</param>
        private void SerializarXml(string path, List<T> elementos)
        {
            using StreamWriter writer = new(path);
            XmlSerializer xmlSerializer = new(typeof(List<T>));
            xmlSerializer.Serialize(writer, elementos);
        }

        /// <summary>
        /// Deserializa un archivo XML en la ruta especificada
        /// </summary>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private List<T>? DeserializarXml<T>(string path)
        {
            using (StreamReader reader = new(path))
            {
                XmlSerializer serializer = new(typeof(T));
                return serializer.Deserialize(reader) as List<T>;
            }
        }
    }
}

