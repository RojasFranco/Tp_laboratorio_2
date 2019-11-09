using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            Alumno alumno = new Alumno(1, "Franco", "Rojas", "37350866", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            int dniPrueba = 37350866;

            Assert.AreEqual(dniPrueba, alumno.DNI);
        }

        [TestMethod]
        public void TestNombre()
        {
            Alumno alumno1 = new Alumno(1, "Fr342anco", "Rojas", "37350866", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            string nombreEsperado = null;

            Assert.AreEqual(nombreEsperado, alumno1.Nombre);
        }

        [TestMethod]
        public void TestQueNoHayaValoresNulos()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidException()
        {
            Profesor profesor = new Profesor(1, "Mauricio", "Cerizza", "91293jdj", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Profesor profesor = new Profesor(1, "Mauricio", "Cerizza", "98999999", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }
    }
}
