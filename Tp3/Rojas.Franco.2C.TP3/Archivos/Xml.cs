using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos como Xml en archivo
        /// </summary>
        /// <param name="archivo">Lugar donde guardar</param>
        /// <param name="datos">Dato a guardar</param>
        /// <returns>True si pudo guardar, caso contrario lanza ArchivosException</returns>
        public bool GuardarArchivo(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    serializador.Serialize(writer, datos);
                }                                
            }            
            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }                        
            return true;
        }

        /// <summary>
        /// Lee Xml en archivo y lo guarda en datos
        /// </summary>
        /// <param name="archivo">Archivo Xml de donde leer</param>
        /// <param name="datos">Donde guarda el archivo</param>
        /// <returns>True si pudo leer, caso contrario lanza ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextReader reader = new XmlTextReader("url"))
                {
                    datos = (T)(serializador.Deserialize(reader));
                }
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception);
            }
            return true;
        }
    }
}
