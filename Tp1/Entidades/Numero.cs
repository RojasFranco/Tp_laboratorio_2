using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Asigna el valor en el atributo del objeto
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);                
            }
        }
        

        #region Constructores
        /// <summary>
        /// Constructor inicial
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con parametro double
        /// </summary>
        /// <param name="numero">numero a asignar al atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor validando numero recibido como string
        /// </summary>
        /// <param name="strNumero">numero recibido como string</param>
        public Numero(string strNumero)
        {
            
            SetNumero = strNumero;
            
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Valida que el dato recibido sea numero
        /// </summary>
        /// <param name="strNumero">numero recibido como string</param>
        /// <returns>retorna el numero recibido si es valido, 0 en caso contrario</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            
            if(!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }
            return retorno;            
        }
        
        /// <summary>
        /// Convierte numero binario en decimal
        /// </summary>
        /// <param name="binario">numero recibido como string</param>
        /// <returns>retorna el binario en decimal, o valor invalido si no es posible convertirlo</returns>
        public static string BinarioDecimal(string binario)
        {
            double retorno=0;            
            int tamanoBinario = binario.Length;
            
            for(int j=0; j<tamanoBinario; j++)
            {
                if(binario[j]!='1' && binario[j]!='0')
                {
                    return "Valor invalido";                     
                }
            }            
            
            for(int i=0; i<tamanoBinario; i++)
            {
                if(binario[i]=='0')
                {
                    retorno += 0;
                }
                else
                {
                    retorno += Math.Pow(2, tamanoBinario - 1 - i);
                }                
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Convierte numero decimal a binario
        /// </summary>
        /// <param name="numero">numero recibido</param>
        /// <returns>retorna el numero convertido, caso contrario un string vacio</returns>
        public static string DecimalBinario(double numero)
        {
            string retorno=string.Empty;
            int auxNumero = (int)numero;            
            
            while((auxNumero/2)>1)
            {
                retorno = string.Format("{0}{1}", auxNumero % 2, retorno);
                auxNumero = auxNumero / 2;
            }            
            retorno = string.Format("{0}{1}{2}",auxNumero / 2, auxNumero%2 ,retorno);            
            return retorno;
        }

        /// <summary>
        /// Convierte numero decimal a binario
        /// </summary>
        /// <param name="strNumero">numero recibido como string</param>
        /// <returns>Numero converdiro a binario, caso contrario valor invalido</returns>
        public static string DecimalBinario(string strNumero)
        {
            string retorno = string.Empty;
            Numero numeroRecibido = new Numero();
            numeroRecibido.SetNumero = strNumero;            
            if(numeroRecibido.numero>=1)
            {
                retorno = Numero.DecimalBinario(numeroRecibido.numero);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }


        #endregion


        #region Sobrecargas

        /// <summary>
        /// Realiza resta entre el numero de 2 objetos
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns>resultado de la resta entre los numeros</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Realiza suma entre el numero de 2 objetos
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns>resultado de la resta entre los numeros</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Realiza multiplicacion entre el numero de 2 objetos
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns>resultado de la multiplicacion entre los numeros</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Realiza division entre el numero de 2 objetos
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <returns>division entre los numeros, o el minimo valor doble en caso contrario</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            if (num2.numero==0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = num1.numero / num2.numero;
            }
            return retorno;
        }

        #endregion

    }
}
