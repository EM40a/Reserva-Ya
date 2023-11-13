using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos.Tests
{
    [TestClass()]
    public class HuespedTests
    {
        [TestMethod()]
        [DataRow("23456789", "+54 9 11 2345-6789")]
        [DataRow("22334455", "+54 9 11 2233-4455")]
        [DataRow("98765432", "+54 9 11 9876-5432")]
        [DataRow(" 44432221 ", "+54 9 11 4443-2221")]
        public void FormatearTelefonoTest_SiSeIngresaUnNumero_ElNumeroFormateado
            (string telefono, string valorEsperado)
        {
            //Arrange: Preparar el escenario de la prueba
            Huesped huesped = new();

            huesped.SetTelefono(telefono);
            string resultado = huesped.Telefono;

            //Act: Ejecutar el metodo a probar
            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}