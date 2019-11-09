using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor profesor;


        #region Constructores

        /// <summary>
        /// Constructor jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor jornada recibiendo parametros
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="profesor">profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor profesor) : this()
        {
            this.clase = clase;
            this.profesor = profesor;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad lee o asigna lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }


        /// <summary>
        /// Propiedad que lee o asigna la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad que lee o asigna un profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda jornada como texto
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>True si pudo guardar, sino lanza ArchivoException</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();            
            return texto.GuardarArchivo(AppDomain.CurrentDomain.BaseDirectory+"\\miJornada.txt", jornada.ToString());


        }
        
        /// <summary>
        /// Lee una jornada como archivo de texto
        /// </summary>
        /// <returns>retorna la jornada si pudo leer, sino lanza ArchivoException</returns>
        public static string Leer()
        {
            string retorno;
            Texto texto = new Texto();
            if(texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\miJornada.txt", out retorno))
            {
                return retorno;
            }
            return null;
        }
        

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>Retorna los datos de la jornada como string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendFormat(" CLASE DE: {0}", this.Clase);
            sb.AppendFormat(" POR {0} \n", this.Instructor);
            sb.AppendLine(" Alumnos: ");
            foreach (Alumno alumnosDeJornada in this.Alumnos)
            {
                sb.Append(alumnosDeJornada.ToString());                
            }


            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara una jornada con un alumno
        /// </summary>
        /// <param name="jornada">jornada a comparar</param>
        /// <param name="alumno">alumno a verificar si esta en la jornada</param>
        /// <returns>True si el alumno esta en la jornada, False caso contrario</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool retorno = false;
            foreach(Alumno alumnoEnJornada in jornada.Alumnos)
            {
                if(alumnoEnJornada == alumno)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara una jornada con un alumno
        /// </summary>
        /// <param name="jornada">jornada a comparar</param>
        /// <param name="alumno">alumno a verificar si esta en la jornada</param>
        /// <returns>False si el alumno esta en la jornada, True caso contrario</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si este no se encuentra ya en ella
        /// </summary>
        /// <param name="jornada">jornada</param>
        /// <param name="alumno">alumno a agregar</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if(jornada!=alumno)
            {
                jornada.Alumnos.Add(alumno);
            }
            return jornada;
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
