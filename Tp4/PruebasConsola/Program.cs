using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Paquete paq = new Paquete("Ucrania", "1224");
            Console.WriteLine(paq);
            Console.ReadKey();
        }
    }
}
