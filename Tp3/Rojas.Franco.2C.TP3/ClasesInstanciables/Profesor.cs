using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;


        #region Constructores

        /// <summary>
        /// Constructor de profesor 
        /// </summary>
        public Profesor() : base()
        {
        }

        /// <summary>
        /// Constructor estatico que inicializa clase random
        /// </summary>
        static Profesor() 
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de profesor que recibe parametros. Inicializa las clases, y genera dos clases con el metodo random
        /// </summary>
        /// <param name="id">id del profesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una clase con random y la encola en clases del dia
        /// </summary>
        private void _randomClases()
        {            
            int posicionRandom = random.Next(0, 4);             
            switch (posicionRandom)
            {
                case 0:                    
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;

                default:
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }

        /// <summary>
        /// Muestra datos del profesor
        /// </summary>
        /// <returns>retorna los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());           
            
            return sb.ToString();
        }

        /// <summary>
        /// Muestra las clases del profesor
        /// </summary>
        /// <returns>retorna las clases del profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Clases del dia: \n");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }            

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si un profesor da la clase
        /// </summary>
        /// <param name="profesor">profesor</param>
        /// <param name="clase">clase a verificar</param>
        /// <returns>True si el profesor da esa clase, False caso contrario</returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach(Universidad.EClases claseDelProfesor in profesor.clasesDelDia)
            {
                if(claseDelProfesor==clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si un profesor da la clase
        /// </summary>
        /// <param name="profesor">profesor</param>
        /// <param name="clase">clase a verificar</param>
        /// <returns>False si el profesor da esa clase, True caso contrario</returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
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
