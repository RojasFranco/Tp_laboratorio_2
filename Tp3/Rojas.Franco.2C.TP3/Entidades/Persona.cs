using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region Propiedades

        /// <summary>
        /// Propiedad, lee o asigna nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(this.ValidarNombreApellido(value)!=null)
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Propiedad que lee o asigna apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if(this.ValidarNombreApellido(value)!=null)
                {
                    this.apellido = value;
                }                
            }
        }

        /// <summary>
        /// Propiedad que lee o asigna dni como int
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad que lee o asigna nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que asigna dni como string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor de persona sin recibir parametros
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor de persona, recibiendo nombre apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido  de la persona</param>
        /// <param name="nacionalidad">nacionalidad  de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de persona, recibiendo nombre apellido dni y nacionalidad
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni  de la persona</param>
        /// <param name="nacionalidad">nacionalidad  de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de persona Constructor de persona, recibiendo nombre apellido dni y nacionalidad
        /// </summary>
        /// <param name="nombre">nombre  de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;            
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dato recibido sea un dni perteneciente a la nacionalidad recibida
        /// </summary>
        /// <param name="nacionalidad">nacionalidad a verificar</param>
        /// <param name="dato">dato a verificar</param>
        /// <returns>devuelve el dni si es valido o lanza excepcion en caso contrario</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad==ENacionalidad.Argentino && dato>=1 && dato<= 89999999
                ||(nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }


        /// <summary>
        /// Valida dni, verificando cantidad de caracteres y que sea convertible a int
        /// </summary>
        /// <param name="nacionalidad">nacionalidad a verificar</param>
        /// <param name="dato">dni a verificar</param>
        /// <returns>retorna dni si es valido, sino lanza excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int valorConvertido;
            int retorno;

            if(dato.Length>0 && dato.Length<9 && int.TryParse(dato, out valorConvertido))
            {                
                retorno = this.ValidarDni(nacionalidad, valorConvertido);
                return retorno;
            }
            else
            {
                throw new DniInvalidoException();                
            }
        }

        /// <summary>
        /// Valida que el dato sea un nombre y/o apellido
        /// </summary>
        /// <param name="dato">dato a verificar</param>
        /// <returns>retorna el dato si es valido, sino null</returns>
        private string ValidarNombreApellido(string dato)
        {            
            foreach(Char caracter in dato)
            {                
                if(!Char.IsLetter(caracter)) // caracter<'A' || caracter>'z' || (caracter>'Z' && caracter<'a' ) )
                {
                    return null;
                }
            }
            return dato;            
        }

        /// <summary>
        /// Representa los datos de una persona
        /// </summary>
        /// <returns>Retorna los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            //sb.AppendFormat(" Dni: {0}\n", this.DNI);
            sb.AppendFormat(" Nacionalidad: {0}\n", this.Nacionalidad);
            
            return sb.ToString();
        }

        #endregion


        #region Enumerate
        /// <summary>
        /// Enumerate con los tipos de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion        


    }
}
