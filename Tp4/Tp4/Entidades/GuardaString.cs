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
                retorno = false;
                throw err;
            }
            return retorno;
        }
    }
}
