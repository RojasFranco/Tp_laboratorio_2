using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class Pruebas
    {
        /// <summary>
        /// Prueba que la lista paquetes de correo este instanciada
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }


        /// <summary>
        /// Prueba que al agregar un paquete con un id ya ingresado en el correo lance excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void paquetesMismoIdTest()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("ucrania 933", "3224");
            Paquete paqueteDos = new Paquete("Av siempre viva 123", "3224");

            correo += paqueteUno;
            correo += paqueteDos;
        }
    }
}
