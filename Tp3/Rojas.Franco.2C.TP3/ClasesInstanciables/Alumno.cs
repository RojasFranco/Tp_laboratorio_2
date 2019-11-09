using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {

        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;


        #region Constructores

        /// <summary>
        /// Constructor alumno
        /// </summary>
        public Alumno() : base()
        {
        }

        /// <summary>
        /// Contructor alumno recibiendo parametros
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="clasesQueToma">clase del de alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }

        /// <summary>
        /// Constructor de alumno recibiendo parametros
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="clasesQueToma">clase del de alumno</param>
        /// <param name="estadoCuenta">estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        
        #region Metodos

        /// <summary>
        /// Devuelve las clase que toma el alumno
        /// </summary>
        /// <returns>Retorna la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" TOMA CLASES DE: {0}\n", this.clasesQueToma);

            return sb.ToString();
        }

        /// <summary>
        /// Muestra datos del alumno internamente por ser protegido
        /// </summary>
        /// <returns>retorna string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat(" ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Muestra datos del alumno
        /// </summary>
        /// <returns>retorna string con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="alumno">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>True si el alumno toma esa clase, false en caso contrario</returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            bool retorno = false;
            if(!(alumno!=clase) && alumno.estadoCuenta!= EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            
            return retorno;
        }

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="alumno">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>False si el alumno toma esa clase, true en caso contrario</returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            bool retorno = false;
            if(alumno.clasesQueToma != clase)
            {                
                retorno = true;
            }
            
            return retorno;
        }

        #endregion

        #region Enum

        /// <summary>
        /// Enumerate con los tipos de estado de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        //PARA SACAR WARNINS
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
