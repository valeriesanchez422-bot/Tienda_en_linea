using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaAvanzada
{
    // Definimos tipos fijos para evitar errores de texto libre
    public enum TipoCliente { Nuevo, Recurrente }
    public enum Destino { Local, Exterior }

    class TiendaEnLinea
    {
        // Constantes con nombres claros
        const decimal UMBRAL_GRATIS = 150000;
        const decimal UMBRAL_EXPRESS = 300000;
        const decimal COSTO_ESTANDAR = 10000;
        const decimal COSTO_EXPRESS = 20000;
        const decimal COSTO_EXTERIOR = 50000;

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión de Envíos v2.0";

            // 1. Captura de datos con validación estricta
            decimal monto = LeerDecimal("Ingrese el monto del pedido:");
            Destino destino = LeerEnum<Destino>("Seleccione el destino (0: Local, 1: Exterior):");
            TipoCliente tipo = LeerEnum<TipoCliente>("Tipo de cliente (0: Nuevo, 1: Recurrente):");
            int cantidadItems = LeerEntero("Ingrese la cantidad de items:");

            // 2. Lógica de Negocio
            var (categoria, costoBase) = CalcularLogistica(monto, tipo, cantidadItems);
            
            decimal costoFinal = costoBase;
            if (destino == Destino.Exterior) costoFinal += COSTO_EXTERIOR;

            // 3. Salida Formateada
            MostrarResumen(categoria, costoFinal);
        }

        static (string Categoria, decimal Costo) CalcularLogistica(decimal monto, TipoCliente tipo, int items)
        {
            if (monto >= UMBRAL_GRATIS && tipo == TipoCliente.Recurrente)
                return ("Envío Gratis", 0);

            if (items >= 5 || monto >= UMBRAL_EXPRESS)
                return ("Envío Express", COSTO_EXPRESS);

            return ("Envío Estándar", COSTO_ESTANDAR);
        }

        #region Métodos de Lectura Robusta

        static T LeerEnum<T>(string mensaje) where T : struct, Enum
        {
            Console.WriteLine($"\n{mensaje}");
            T resultado;
            // Solo acepta si el número o nombre corresponde a un valor real del Enum
            while (!Enum.TryParse(Console.ReadLine(), true, out resultado) || !Enum.IsDefined(typeof(T), resultado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Por favor seleccione una opción válida de {typeof(T).Name}.");
                Console.ResetColor();
            }
            return resultado;
        }

        static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.WriteLine(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.WriteLine("Entrada inválida. Ingrese un número decimal positivo:");
            }
            return valor;
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.WriteLine(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.WriteLine("Entrada inválida. Ingrese un número entero positivo:");
            }
            return valor;
        }

        static void MostrarResumen(string cat, decimal costo)
        {
            Console.WriteLine("\n" + new string('=', 30));
            Console.WriteLine("      RESUMEN DEL PEDIDO");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"Categoría: {cat.ToUpper()}");
            Console.WriteLine($"Costo Total: {costo:C0}"); // C0 formatea como moneda local
            
            if (costo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Promoción aplicada: Envío sin costo!");
            }
            else
            {
                Console.WriteLine("Gracias por preferirnos.");
            }
            Console.ResetColor();
            Console.WriteLine(new string('=', 30));
            Console.ReadKey();
        }
        #endregion
    }
}
