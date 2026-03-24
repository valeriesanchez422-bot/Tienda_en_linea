using System;
using System.Collections.Generic;

namespace TiendaAvanzada
{
    public enum TipoCliente { Nuevo, Recurrente }
    public enum Destino { Local, Exterior }

    // Clase para representar un pedido en el historial
    public class RegistroPedido
    {
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
    }

    class TiendaEnLinea
    {
        const decimal UMBRAL_GRATIS = 150000;
        const decimal UMBRAL_EXPRESS = 300000;
        const decimal COSTO_ESTANDAR = 10000;
        const decimal COSTO_EXPRESS = 20000;
        const decimal COSTO_EXTERIOR = 50000;

        static void Main(string[] args)
        {
            // REQUISITO: Uso de List<T>
            List<RegistroPedido> historial = new List<RegistroPedido>();
            string opcion;
            
            // REQUISITO: Uso de do-while para el menú principal
            do
            {
                Console.WriteLine("\n--- SISTEMA DE GESTIÓN DE ENVÍOS v2.0 ---");
                Console.WriteLine("1. Registrar nuevo pedido");
                Console.WriteLine("2. Ver historial de pedidos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                // REQUISITO: Uso de switch para las opciones
                switch (opcion)
                {
                    case "1":
                        ProcesarNuevoPedido(historial);
                        break;
                    case "2":
                        MostrarHistorial(historial);
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

            } while (opcion != "3");
        }

        static void ProcesarNuevoPedido(List<RegistroPedido> historial)
        {
            // REQUISITO: Uso de TryParse y do-while en los métodos de lectura
            decimal monto = LeerDecimal("Ingrese el monto del pedido:");
            Destino destino = LeerEnum<Destino>("Seleccione el destino (0: Local, 1: Exterior):");
            TipoCliente tipo = LeerEnum<TipoCliente>("Tipo de cliente (0: Nuevo, 1: Recurrente):");
            int cantidadItems = LeerEntero("Ingrese la cantidad de items:");

            var (categoria, costoBase) = CalcularLogistica(monto, tipo, cantidadItems);
            
            decimal costoFinal = costoBase;
            if (destino == Destino.Exterior) costoFinal += COSTO_EXTERIOR;

            // Guardar en el historial
            historial.Add(new RegistroPedido { 
                Categoria = categoria, 
                Costo = costoFinal, 
                Fecha = DateTime.Now 
            });

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

        #region Métodos de Lectura con do-while y TryParse

        static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                esValido = decimal.TryParse(Console.ReadLine(), out valor) && valor >= 0;
                if (!esValido) Console.WriteLine("ERROR: Ingrese un monto decimal positivo.");
            } while (!esValido);
            return valor;
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                esValido = int.TryParse(Console.ReadLine(), out valor) && valor >= 0;
                if (!esValido) Console.WriteLine("ERROR: Ingrese un número entero positivo.");
            } while (!esValido);
            return valor;
        }

        static T LeerEnum<T>(string mensaje) where T : struct, Enum
        {
            T resultado;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                string entrada = Console.ReadLine();
                esValido = Enum.TryParse(entrada, true, out resultado) && Enum.IsDefined(typeof(T), resultado);
                if (!esValido) Console.WriteLine($"ERROR: Opción no válida para {typeof(T).Name}.");
            } while (!esValido);
            return resultado;
        }
        #endregion

        static void MostrarResumen(string cat, decimal costo)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("      RESUMEN DEL PEDIDO");
            Console.WriteLine("==============================");
            Console.WriteLine($"Categoría: {cat.ToUpper()}");
            Console.WriteLine($"Costo Total: ${costo}"); 
            if (costo == 0) Console.WriteLine("¡Promoción aplicada: Envío sin costo!");
            Console.WriteLine("==============================\n");
        }

        static void MostrarHistorial(List<RegistroPedido> historial)
        {
            Console.WriteLine("\n--- HISTORIAL DE PEDIDOS ---");
            if (historial.Count == 0) Console.WriteLine("No hay pedidos registrados.");
            
            foreach (var p in historial)
            {
                Console.WriteLine($"[{p.Fecha:HH:mm:ss}] Cat: {p.Categoria} - Total: ${p.Costo}");
            }
        }
    }
}
