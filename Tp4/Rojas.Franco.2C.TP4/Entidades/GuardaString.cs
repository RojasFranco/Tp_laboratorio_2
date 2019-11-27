using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guardara informacion en un archivo de texto en escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">ubicacion</param>
        /// <returns>True si pudo guardar, sino lanza excepcion</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool append;
            bool retorno;

            if (File.Exists(archivo))
            {
                append = true;
            }            
            else
            {
                append = false;
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, append))
                {
                    writer.Write(texto);
                    retorno = true;
                }
            }            
            catch(Exception err)
            {
                throw err;
            }
            return retorno;
        }
    }
}
