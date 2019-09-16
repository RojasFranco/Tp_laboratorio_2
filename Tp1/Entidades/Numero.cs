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

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);                
            }
        }
        

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            double strADouble = Convert.ToDouble(strNumero);
            this.numero = strADouble;
        }

        #endregion

        #region Metodos
        
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            
            if(!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }
            return retorno;            
        }
        
        
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
        
        public static string DecimalBinario(string strNumero)
        {
            string retorno = string.Empty;
            Numero numeroRecibido = new Numero();
            numeroRecibido.SetNumero = strNumero;            
            if(numeroRecibido.numero>0)
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

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

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
