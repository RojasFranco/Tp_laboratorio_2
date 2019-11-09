using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos recibidos como string en un archivo de texto
        /// </summary>
        /// <param name="archivo">lugar donde guardar</param>
        /// <param name="datos">string a guardar</param>
        /// <returns>True si pudo guardar, caso contrario lanza ArchivosException</returns>
        public bool GuardarArchivo(string archivo, string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    string[] lineas = datos.Split('\n');
                    foreach(string lineaEscribir in lineas) //Preguntar
                    {
                        escritor.WriteLine(lineaEscribir);
                    }                    
                    return true;
                }                
            }
            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }               
        }

        /// <summary>
        /// Lee un archivo de texto y lo guarda en string datos
        /// </summary>
        /// <param name="archivo">Archivo a leer</param>
        /// <param name="datos">Lugar donde guardar el archivo</param>
        /// <returns>True si pudo leer, caso contrario lanza ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = lector.ReadToEnd();                    
                }
                return true;
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception);
            }            
        }
    }
}
