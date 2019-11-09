using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using Archivos;


namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;


        #region Constructores

        /// <summary>
        /// Constructor de universidad. Inicializa alumnos, jornadas y profesores
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion
        #region Metodos

        /// <summary>
        /// Guarda la universidad como Xml
        /// </summary>
        /// <param name="universidad">universidad a guardar</param>
        /// <returns>True si lo guardo, caso contrario lanza ArchivosException</returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> xmlGuardar = new Xml<Universidad>();
            return (xmlGuardar.GuardarArchivo(AppDomain.CurrentDomain.BaseDirectory + "\\miUniversidad.Xml", universidad));            
        }

        /// <summary>
        /// Lee una universidad de un archivo Xml
        /// </summary>
        /// <returns>Retorna la universidad si pudo leer, sino lanza ArchivosException</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> xmlLeer = new Xml<Universidad>();
            xmlLeer.Leer(AppDomain.CurrentDomain.BaseDirectory + "miUniversidad.Xml", out retorno);

            return retorno;
        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="universidad">universidad a mostrar</param>
        /// <returns>Retorna datos de la universidad</returns>
        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder sb = new StringBuilder();            
            foreach(Jornada jornadaEnUniversidad in universidad.Jornadas)
            {
                sb.AppendLine(" Jornada:");
                sb.Append(jornadaEnUniversidad.ToString());
                sb.AppendLine("<----------------------------------------->");
            }
            return sb.ToString();

        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <returns>Retorna datos de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion
        #region Propiedades

        /// <summary>
        /// Propiedad que lee o asigna lista de alumnos
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
        /// Propiedad que lee o asigna lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad que lee o asigna lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Indexador de jornada, lee o asigna jornada segun su indice
        /// </summary>
        /// <param name="i">indice</param>
        /// <returns>Retorna la jornada en el indice dado</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];                
            }
            set
            {
                this.jornadas[i] = value;
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si el alumno esta en la universidad
        /// </summary>
        /// <param name="universidad">universidad a verificar</param>
        /// <param name="alumno">alumno a verificar</param>
        /// <returns>True si el alumno esta en la universidad, False caso contrario</returns>
        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            bool retorno = false;
            foreach(Alumno alumnoEnUniversidad in universidad.Alumnos)
            {
                if(alumnoEnUniversidad==alumno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si el alumno esta en la universidad
        /// </summary>
        /// <param name="universidad">universidad a verificar</param>
        /// <param name="alumno">alumno a verificar</param>
        /// <returns>False si el alumno esta en la universidad, True caso contrario</returns>
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        /// <summary>
        /// Verifica si el profesor esta en esa universidad
        /// </summary>
        /// <param name="universidad">universidad a verificar</param>
        /// <param name="profesor">profesor a verificar</param>
        /// <returns>True si el profesor esta en la universidad, False caso contrario</returns>
        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            bool retorno = false;
            foreach(Profesor profesorEnUniversidad in universidad.Instructores)
            {
                if(profesorEnUniversidad==profesor)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si el profesor esta en esa universidad
        /// </summary>
        /// <param name="universidad">universidad a verificar</param>
        /// <param name="profesor">profesor a verificar</param>
        /// <returns>False si el profesor esta en la universidad, True caso contrario</returns>
        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        /// <summary>
        /// Busca profesor dentro de la universidad que de la clase
        /// </summary>
        /// <param name="universidad">universidad donde buscar profesor</param>
        /// <param name="clase">clase a verificar</param>
        /// <returns>Retorna el primer profesor que de la clase,, o SinProfesorException si no hay alguno que la de</returns>
        public static Profesor operator ==(Universidad universidad, EClases clase)
        {            
            foreach(Profesor profesor in universidad.Instructores)
            {
                if(profesor==clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el primer profesor que no pueda dar la clase
        /// </summary>
        /// <param name="universidad">universidad donde buscar profesor</param>
        /// <param name="clase">clase a verificar</param>
        /// <returns>Retorna el primer profesor que no de la clase, o SinProfesorException si todos los prof la dan</returns>
        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesor in universidad.Instructores)
            {
                if(profesor!=clase)
                {
                    return profesor;
                }                
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una jornada a universidad con la clase, un profesor que pueda darla, y los alumnos que la toman.
        /// </summary>
        /// <param name="universidad">universidad</param>
        /// <param name="clase">clase a verificar</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Jornada jornadaAAgregar;
            Profesor profesorQueDeLaClase = (universidad==clase);
            
            jornadaAAgregar = new Jornada(clase, profesorQueDeLaClase);

            foreach(Alumno alumno in universidad.alumnos)
            {
                if(alumno == clase)
                {
                    jornadaAAgregar += alumno;
                }                
            }
            universidad.Jornadas.Add(jornadaAAgregar);
            return universidad;


        }

        /// <summary>
        /// Agrega alumno a universidad 
        /// </summary>
        /// <param name="universidad"universidad></param>
        /// <param name="alumno">alumno a agregar</param>
        /// <returns>Retorna universidad si pudo agregar al alumno, oAlumnoRepetidoException si ya estaba en ella</returns>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if(universidad!=alumno)
            {
                universidad.Alumnos.Add(alumno);
                return universidad;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }            
        }

        /// <summary>
        /// Agrega profesor a universidad si este no se encuentra ahi
        /// </summary>
        /// <param name="universidad">universidad</param>
        /// <param name="profesor">profesor</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if(universidad!=profesor)
            {
                universidad.Instructores.Add(profesor);
            }
            return universidad;
        }

        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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
