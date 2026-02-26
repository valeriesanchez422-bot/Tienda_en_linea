using System;
					
class Tienda_en_linea
{
    static void Main(string[] args)
    {
        //Entradas
        Console.WriteLine("Ingrese el monto del pedido:");
        decimal monto = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Ingrese la ciudad destino:");
        string ciudad = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese el tipo de cliente (nuevo/recurrente):");
        string tipoCliente = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese la cantidad de items:");
        int cantidadItems = Convert.ToInt32(Console.ReadLine());

        //Variables de salida
        string categoria;
        decimal costoEnvio = 0;

        //Reglas de clasificación
        if (monto >= 150000 && tipoCliente == "recurrente")
        {
            categoria = "Envío Gratis";
            costoEnvio = 0;
        }
        else if (cantidadItems >= 5 || monto >= 300000)
        {
            categoria = "Envío Express";
            costoEnvio = 20000;
        }
        else
        {
            categoria = "Envío Estándar";
            costoEnvio = 10000;
        }

        //Costo adicional si es exterior
        if (ciudad == "exterior")
        {
            costoEnvio += 50000;
        }

        //Salida final
        Console.WriteLine("\n--- Resultado del Pedido ---");
        Console.WriteLine("Categoría de despacho: " + categoria);
        Console.WriteLine("Costo de envío: $" + costoEnvio);

        if (costoEnvio == 0)
        {
            Console.WriteLine("¡Felicidades! Tu envío es completamente gratis.");
        }
        else
        {
            Console.WriteLine("Gracias por tu compra.");
        }

        Console.ReadLine();
    }
}
