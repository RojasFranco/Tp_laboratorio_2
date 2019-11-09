using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "Dni invalido, cantidad de caracteres o caracter invalido";

        public DniInvalidoException() : this(DniInvalidoException.mensajeBase)
        {            
        }

        public DniInvalidoException(Exception e) : this(DniInvalidoException.mensajeBase, e)
        {
        }

        public DniInvalidoException(string message) : this(message, null)
        {
        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }

    }
}
