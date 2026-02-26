using System;
					
class TiendaEnLinea

{
	// Constantes
const decimal MONTO_ENVIO_GRATIS = 150000;
const decimal MONTO_ENVIO_EXPRESS = 300000;
const decimal COSTO_ESTANDAR = 10000;
const decimal COSTO_EXPRESS = 20000;
const decimal COSTO_EXTERIOR = 50000;

    static void Main(string[] args)
    {
        //Entradas
        decimal monto = LeerDecimal("Ingrese el monto del pedido:");


        string ciudad = LeerTexto("Ingrese la ciudad destino:");


        string tipoCliente = LeerTexto("Ingrese el tipo de cliente (nuevo/recurrente):");


        int cantidadItems = LeerEntero("Ingrese la cantidad de items:");


        //Variables de salida
        string categoria;
        decimal costoEnvio = 0;

        //Reglas de clasificación
       if (monto >= MONTO_ENVIO_GRATIS && tipoCliente == "recurrente")

        {
            categoria = "Envío Gratis";
            costoEnvio = 0;
        }
        else if (cantidadItems >= 5 || monto >= MONTO_ENVIO_EXPRESS)

        {
            categoria = "Envío Express";
            costoEnvio = COSTO_EXPRESS;

        }
        else
        {
            categoria = "Envío Estándar";
            costoEnvio = COSTO_ESTANDAR;

        }

        //Costo adicional si es exterior
        if (ciudad == "exterior")
{
    costoEnvio += COSTO_EXTERIOR;
}


        //Salida final
        Console.WriteLine("\n--- Resultado del Pedido ---");
		Console.WriteLine($"Categoría de despacho: {categoria}");
        Console.WriteLine($"Costo de envío: ${costoEnvio:N0}");

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
	static decimal LeerDecimal(string mensaje)
{
    decimal valor;
    Console.WriteLine(mensaje);

    while (!decimal.TryParse(Console.ReadLine(), out valor))
    {
        Console.WriteLine("Valor inválido. Intente nuevamente:");
    }

    return valor;
}

static int LeerEntero(string mensaje)
{
    int valor;
    Console.WriteLine(mensaje);

    while (!int.TryParse(Console.ReadLine(), out valor))
    {
        Console.WriteLine("Valor inválido. Intente nuevamente:");
    }

    return valor;
}

static string LeerTexto(string mensaje)
{
    Console.WriteLine(mensaje);
    return Console.ReadLine().ToLower().Trim();
}

}
