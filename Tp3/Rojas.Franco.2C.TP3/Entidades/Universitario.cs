using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;


        #region Constructores

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor de universitario
        /// </summary>
        /// <param name="legajo">legajo de universitario</param>
        /// <param name="nombre">nombre de universitario</param>
        /// <param name="apellido">apellido de universitario</param>
        /// <param name="dni">dni de universitario</param>
        /// <param name="nacionalidad">nacionalidad de universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido,dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Muestra todos los datos de universitario
        /// </summary>
        /// <returns>retorna el universitario con sus datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat(" \nLEGAJO NUMERO: {0} \n", this.legajo);

            return sb.ToString();            
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara dos universitarios
        /// </summary>
        /// <param name="universitario1">Primer universitario</param>
        /// <param name="universitario2">Segundo universitario</param>
        /// <returns>Retorna true si son del mismo tipo y sus legajos o dni son iguales, false caso contrario</returns>
        public static bool operator ==(Universitario universitario1, Universitario universitario2)
        {
            if(universitario1.Equals(universitario2) && (universitario1.legajo==universitario2.legajo || universitario1.DNI==universitario2.DNI))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compara dos universitarios
        /// </summary>
        /// <param name="universitario1">Primer universitario</param>
        /// <param name="universitario2">Segundo universitario</param>
        /// <returns>Retorna false si son del mismo tipo y sus legajos o dni son iguales, true caso contrario</returns>
        public static bool operator !=(Universitario universitario1, Universitario universitario2)
        {
            return !(universitario1 == universitario2);
        }

        /// <summary>
        /// Compara el objeto recibido con el tipo de esta clase
        /// </summary>
        /// <param name="obj">objeto recibido</param>
        /// <returns>Retorna true si los objetos son iguales</returns>
        public override bool Equals(object obj)
        {
            return (this.GetType() == obj.GetType());            
        }

        //PARA SACAR WARNINS
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
