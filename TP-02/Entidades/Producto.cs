using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {

        /// <summary>
        /// Tipos de marca
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codigo">codigo de producto</param>
        /// <param name="marca">Marca de producto</param>
        /// <param name="color">Color de producto</param>
        public Producto(string codigo, Producto.EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            string retorno = (string) this;
            return retorno;
        }

        /// <summary>
        /// Convierte explicitamente un producto en un string con todos sus detalles
        /// </summary>
        /// <param name="p">producto a convertir</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");            

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="producto1">Primer producto</param>
        /// <param name="producto2">Segundo producto</param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.codigoDeBarras == producto2.codigoDeBarras);
        }


        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="producto1">Primer producto</param>
        /// <param name="producto2">Segundo producto</param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1.codigoDeBarras == producto2.codigoDeBarras);
        }
    }
}
