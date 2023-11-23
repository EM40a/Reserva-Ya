using Entidades.Excepciones;
using Entidades.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Modelos.Tests
{
    [TestClass()]
    public class HuespedTests
    {
        [TestMethod()]
        [DataRow("2001-12-27", true)]
        [DataRow("2002-11-14", true)]
        [DataRow("2003-12-22", true)]
        [DataRow("2003-3-7", true)]
        [DataRow("2004-11-08", true)]
        [DataRow("2005-11-14", true)]
        public void EsMayorDeEdad_CuandoEdadEsMas18_DeberiaRetronarTrue
            (string fechaDeNacimiento, bool valorEsperado)
        {
            //Arrange: Preparar el escenario de la prueba
            bool resultado;
            DateTime dateTest = DateTime.Parse(fechaDeNacimiento);

            //Act: Ejecutar el metodo a probar
            resultado = Huesped.EsMayorDeEdad(dateTest);

            //Assert: Verificar el resultado
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod()]
        [DataRow("2009-12-27", false)]
        [DataRow("2010-11-14", false)]
        [DataRow("2011-12-22", false)]
        [DataRow("2012-3-7", false)]
        [DataRow("2013-11-08", false)]
        [DataRow("2014-11-14", false)]
        public void EsMayorDeEdad_CuandoEdadEsMenor18_DeberiaRetronarFalse
            (string fechaDeNacimiento, bool valorEsperado)
        {
            //? Arrange: Preparar el escenario de la prueba
            bool resultado;
            DateTime dateTest = DateTime.Parse(fechaDeNacimiento);

            //? Act: Ejecutar el metodo a probar
            resultado = Huesped.EsMayorDeEdad(dateTest);

            //? Assert: Verificar el resultado
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod()]
        [DataRow("Juan", true)]
        [DataRow("Juan Carlos", true)]
        public void ValidaCampoVacio_CuandoPasoValoresValidos_DeberiaRetornarTrue
            (string campo, bool valorEsperado)
        {
            //? Arrange: Preparar el escenario de la prueba
            bool resultado;

            //? Act: Ejecutar el metodo a probar
            resultado = Huesped.ValidaCampoVacio(campo);

            //? Assert: Verificar el resultado
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void ValidaCampoVacio_CuandoPasoValoresInvalidos_DeberiaLanzarUnaExcepcion(string campo)
        {
            //? Arrange: Preparar el escenario de la prueba
            Action action;

            //? Act: Ejecutar el metodo a probar
            action = () => Huesped.ValidaCampoVacio(campo);
            
            //? Assert: Verificar el resultado
            Assert.ThrowsException<DatoInvalidoException>(action);
        }
    }
}