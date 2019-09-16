using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

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
