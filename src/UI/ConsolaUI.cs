using Tienda_en_linea.Models;

namespace Tienda_en_linea.UI
{
    public static class ConsolaUI
    {
        /// <summary>
        /// Solicita al usuario los datos necesarios para crear un pedido.
        /// </summary>
        /// <returns>Devuelve un objeto Pedido con los datos ingresados.</returns>
        public static Pedido LeerPedido()
        {
            Pedido pedido = new Pedido();

            Console.Write("Ingrese el nombre del cliente: ");
            pedido.NombreCliente = Console.ReadLine();

            pedido.TotalCompra = LeerDecimal("Ingrese el total de la compra: ");
            pedido.CantidadProductos = LeerEntero("Ingrese la cantidad de productos: ");

            pedido.EsClienteFrecuente = LeerBooleano("¿Es cliente frecuente? (S/N): ");
            pedido.TieneCupon = LeerBooleano("¿Tiene cupón de descuento? (S/N): ");

            return pedido;
        }

        /// <summary>
        /// Muestra en consola el resultado final del pedido.
        /// </summary>
        /// <param name="pedido">Pedido original.</param>
        /// <param name="resultado">Resultado calculado del pedido.</param>
        public static void MostrarResultado(Pedido pedido, ResultadoPedido resultado)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("       RESUMEN DEL PEDIDO     ");
            Console.WriteLine("==============================");

            Console.WriteLine($"Cliente: {pedido.NombreCliente}");
            Console.WriteLine($"Subtotal: {resultado.Subtotal:C}");
            Console.WriteLine($"Descuento: {resultado.Descuento:C}");
            Console.WriteLine($"Envío: {resultado.CostoEnvio:C}");
            Console.WriteLine($"TOTAL FINAL: {resultado.TotalFinal:C}");
            Console.WriteLine($"Mensaje: {resultado.Mensaje}");

            Console.WriteLine("==============================\n");
        }

        /// <summary>
        /// Lee un valor decimal asegurando que sea válido.
        /// </summary>
        private static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                    return valor;

                Console.WriteLine(" Error: ingrese un número válido.");
            }
        }

        /// <summary>
        /// Lee un valor entero asegurando que sea válido.
        /// </summary>
        private static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                    return valor;

                Console.WriteLine(" Error: ingrese un número entero válido.");
            }
        }

        /// <summary>
        /// Lee una respuesta tipo sí/no desde consola.
        /// </summary>
        private static bool LeerBooleano(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string respuesta = Console.ReadLine().ToUpper();

                if (respuesta == "S")
                    return true;

                if (respuesta == "N")
                    return false;

                Console.WriteLine(" Error: responda con S o N.");
            }
        }
    }
}
