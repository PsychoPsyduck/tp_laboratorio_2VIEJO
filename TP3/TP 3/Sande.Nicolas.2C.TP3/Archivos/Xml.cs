using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>
    {
        /// <summary>
        /// Guarda un dato en un archivo serializado
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="datos">los datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar .xml", e);
            }
            finally
            {
                writer.Close();
            }
            return true;
        }
        /// <summary>
        /// Guarda un dato en un archivo serializado
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="datos">donde guarda los datos leidos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            try
            {
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer .xml", e);
            }
            finally
            {
                reader.Close();
            }
            return true;
        }
    }
}
