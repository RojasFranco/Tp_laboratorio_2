using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        /// <summary>
        /// Tipos de leche
        /// </summary>
        public enum ETipo { Entera, Descremada }

        private ETipo tipo;

        /// <summary>
        /// Constructor Leche, Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca leche</param>
        /// <param name="codigo">Codigo de leche</param>
        /// <param name="color">Color de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca, codigo, color, Leche.ETipo.Entera)
        {
        }

        /// <summary>
        /// Constructor Leche
        /// </summary>
        /// <param name="marca">Marca Leche</param>
        /// <param name="codigo">Codigo de leche</param>
        /// <param name="color">Color de leche</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Devuelve los atributos de la leche
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
