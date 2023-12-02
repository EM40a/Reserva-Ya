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

                    case "csv":
                        SerializarCsv(path, elementos);
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

                    case "csv":
                        return DeserializarCsv<T>(directorio);

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
                throw new ArchivoInvalidoException("Error al importar");
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
        /// <summary>
        /// Serializa una lista de objetos en formato CSV y guarda el resultado en un archivo en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo CSV.</param>
        /// <param name="elementos">Lista de objetos a serializar.</param>
        private void SerializarCsv(string path, List<T> elementos)
        {
            using (StreamWriter sw = new(path))
            {
                // Encabezado CSV (usando propiedades de la primera instancia de T)
                var encabezado = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                sw.WriteLine(encabezado);

                // Escribir cada línea de datos en el archivo
                foreach (var elemento in elementos)
                {
                    // Valores CSV
                    var valores = string.Join(",", typeof(T).GetProperties().Select(p => p.GetValue(elemento)?.ToString()));
                    sw.WriteLine(valores);
                }
            }
        }

        /// <summary>
        /// Deserializa un archivo CSV ubicado en la ruta especificada y devuelve una lista de objetos del tipo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a deserializar.</typeparam>
        /// <param name="path">Ruta del archivo CSV.</param>
        /// <returns>Una lista de objetos del tipo especificado con datos del archivo CSV.</returns>
        /// <exception cref="ArchivoInvalidoException">Se lanza cuando ocurre un error durante la deserialización del archivo.</exception>
        private List<T>? DeserializarCsv<T>(string path)
        {
            try
            {
                using (StreamReader sr = new(path))
                {
                    List<T> elementos = new();
                    string[] encabezados = sr.ReadLine()?.Split(',');

                    while (sr.Peek() >= 0)
                    {
                        string[] valores = sr.ReadLine()?.Split(',');

                        if (valores != null && valores.Length == encabezados?.Length)
                        {
                            T elemento = ConstruirElementoDesdeCsv<T>(encabezados, valores);
                            elementos.Add(elemento);
                        }
                    }

                    return elementos;
                }
            }
            catch (Exception)
            {
                throw new ArchivoInvalidoException("Error al importar el archivo CSV");
            }
        }


        /// <summary>
        /// Construye un objeto del tipo especificado desde un conjunto de encabezados y valores provenientes de un archivo CSV.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a construir.</typeparam>
        /// <param name="encabezados">Array que contiene los encabezados del CSV.</param>
        /// <param name="valores">Array que contiene los valores asociados a los encabezados en una línea del CSV.</param>
        /// <returns>Un objeto del tipo especificado con propiedades asignadas según los encabezados y valores proporcionados.</returns>
        private T ConstruirElementoDesdeCsv<T>(string[] encabezados, string[] valores)
        {
            T elemento = Activator.CreateInstance<T>();

            for (int i = 0; i < encabezados.Length; i++)
            {
                var propiedad = typeof(T).GetProperty(encabezados[i].Trim());

                if (propiedad != null)
                {
                    propiedad.SetValue(elemento, Convert.ChangeType(valores[i]?.Trim(), propiedad.PropertyType));
                }
            }

            return elemento;
        }
    }
}

