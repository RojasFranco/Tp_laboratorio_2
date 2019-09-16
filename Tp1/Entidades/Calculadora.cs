using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida operador recibido sea valido
        /// </summary>
        /// <param name="operador">operador recibido a validar</param>
        /// <returns>Si el operador es valido devuelve el mismo, + en caso contrario</returns>
        private static string ValidarOperador(string operador)
        {

            if(operador=="+" || operador=="-" || operador=="*" || operador=="/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        /// <summary>
        /// Realiza operacion entre dos numeros
        /// </summary>
        /// <param name="num1">Primer numero a operar</param>
        /// <param name="num2">Segundo numero a operar</param>
        /// <param name="operador">operador a aplicar entre los numeros</param>
        /// <returns>retorna el resultado de la operacion, 0 en su defecto
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno=0;            
            switch(ValidarOperador(operador))
            {                
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":                
                    retorno = num1 / num2;
                    break;                   
            }

            return retorno;
        }
    }
}
