using Tienda_en_linea.Models;

namespace Tienda_en_linea.Services
{
    public static class CalculoService
    {
        /// <summary>
        /// Calcula el descuento del pedido según reglas de negocio.
        /// </summary>
        /// <param name="pedido">Objeto Pedido con los datos del cliente y compra.</param>
        /// <returns>Devuelve el valor del descuento aplicado.</returns>
        public static decimal CalcularDescuento(Pedido pedido)
        {
            decimal descuento = 0;

            // Descuento por cliente frecuente
            if (pedido.EsClienteFrecuente)
                descuento += pedido.TotalCompra * 0.10m;

            // Descuento por cupón
            if (pedido.TieneCupon)
                descuento += pedido.TotalCompra * 0.05m;

            return descuento;
        }

        /// <summary>
        /// Calcula el costo de envío según el total de compra.
        /// </summary>
        /// <param name="totalCompra">Valor total de la compra.</param>
        /// <returns>Devuelve el costo de envío.</returns>
        public static decimal CalcularEnvio(decimal totalCompra)
        {
            if (totalCompra >= 200000)
                return 0;

            return 15000;
        }

        /// <summary>
        /// Procesa un pedido y retorna el resultado completo.
        /// </summary>
        /// <param name="pedido">Pedido con la información del cliente y compra.</param>
        /// <returns>Devuelve un ResultadoPedido con subtotal, descuento, envío y total final.</returns>
        public static ResultadoPedido ProcesarPedido(Pedido pedido)
        {
            decimal descuento = CalcularDescuento(pedido);
            decimal envio = CalcularEnvio(pedido.TotalCompra);

            decimal totalFinal = (pedido.TotalCompra - descuento) + envio;

            return new ResultadoPedido
            {
                Subtotal = pedido.TotalCompra,
                Descuento = descuento,
                CostoEnvio = envio,
                TotalFinal = totalFinal,
                Mensaje = "Pedido procesado correctamente."
            };
        }
    }
}
