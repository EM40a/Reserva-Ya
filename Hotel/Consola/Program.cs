using Entidades.Archivos;
using Entidades.BaseDeDatos;
using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static Entidades.Modelos.Reserva;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManejadorDeArchivos<Reserva> manejadorDeArchivos = new();
                manejadorDeArchivos.GuardarArchivo("reservas.xml", new Reserva()
                { 
                    FechaEntrada=DateTime.Today.AddDays(9).ToString(),
                    FechaSalida=DateTime.Today.AddDays(16).ToString(),
                    Valor=350,
                    FormaDePago="Efectivo"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}