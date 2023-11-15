using Entidades.Excepciones;
using System.Text.Json;
using System.Xml.Serialization;

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
        /// <exception cref="ArchivoInvalidoException"></exception>
        public void ExportarArchivo(string path, List<T> elementos)
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
                    throw new ArchivoInvalidoException("Extensión no permitida");
            }
        }

        /// <summary>
        /// Importa un archivo desde el directorio recibido por parametro segun la extencion del archivo (JSON o XML)/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>Una <see cref="List{T}"/> con los elementos deserializados</returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public List<T>? ImportarArchivo<T>(string path)
        {
            string extension = Path.GetExtension(path.TrimStart('.'));

            switch(extension.TrimStart('.').ToLower())
            {
                case "json":
                    return DeserializarJson<T>(path);

                case "xml":
                    return DeserializarXml<T>(path);

                default:
                    throw new ArchivoInvalidoException("Extensión no permitida");
            }
        }

        /// <summary>
        /// Serializa un objeto a JSON
        /// </summary>
        /// <param name="nombreArchivo">Es el nombre del archivo a guardar</param>
        /// <param name="elemento">El objeto a serializar</param>
        /// <exception cref="ArchivoInvalidoException"></exception>"
        private void SerializarJson(string path, List<T> elemento)
        {
            try
            {
                JsonSerializerOptions opciones = new();
                opciones.WriteIndented = true;
                
                using (StreamWriter sw = new(path)) 
                { 
                    string strJson = JsonSerializer.Serialize(elemento, opciones);
                    sw.WriteLine(strJson);
                }
            }
            catch(JsonException)
            {
                throw new ArchivoInvalidoException("Error al guardar el archivo JSON");
            }
        }

        /// <summary>
        /// Deserializa un archivo JSON con los datos del tipo de dato recibido por parametro
        /// </summary>
        /// <returns>Una <see cref="List{T}"/> con los elementos deserializados</returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private List<T>? DeserializarJson<T>(string path)
        {
            try
            {
                using (StreamReader reader = new(path))
                {
                    string strJson = reader.ReadToEnd();
                    
                    return JsonSerializer.Deserialize<List<T>>(strJson);
                }
            }
            catch (JsonException)
            {
                throw new ArchivoInvalidoException("No es posible leer el archivo JSON");
            }
        }

        /// <summary>
        /// Serializa un objeto a XML en la ruta especificada
        /// </summary>
        /// <param name="nombreArchivo">Es el nombre del archivo a guardar</param>
        /// <param name="elementos">El objeto a serializar</param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private void SerializarXml(string path, List<T> elementos)
        {
            try
            {
                using StreamWriter writer = new(path);
                XmlSerializer xmlSerializer = new(typeof(List<T>));
                xmlSerializer.Serialize(writer, elementos);
            }
            catch(IOException)
            {
                throw new ArchivoInvalidoException("Error al guardar el archivo XML");
            }
        }

        /// <summary>
        /// Deserializa un archivo XML en la ruta especificada
        /// </summary>
        /// <exception cref="ArchivoInvalidoException"></exception>
        private List<T>? DeserializarXml<T>(string path)
        {
            try
            {
                using (StreamReader reader = new (path)) 
                {
                    XmlSerializer serializer = new(typeof(T));
                    return serializer.Deserialize(reader) as List<T>;
                }
            }
            catch 
            {
                throw new ArchivoInvalidoException("No es posible leer el archivo XML");
            }
        }
    }
}

