using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        /// <summary>
        /// Guarda un dato en un archivo .txt
        /// </summary>
        /// <param name="archivo">nombre del archivo a crear</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(archivo);
                writer.Write(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar .txt", e);
            }
            finally
            {
                writer.Close();
            }

            return true;
        }
        /// <summary>
        /// Lee un archivo .txt y lo guarda en un string
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">a donde guarda los datos leidos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer .txt", e);
            }
            finally
            {
                reader.Close();
            }
            return true;
        }
    }
}
