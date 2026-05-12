using Tienda_en_linea.Models;

namespace Tienda_en_linea.Services
{
    public static class PedidoController
    {
        /// <summary>
        /// Orquesta el flujo completo del programa: recibe pedido, procesa y retorna resultado.
        /// </summary>
        /// <param name="pedido">Pedido ingresado por el usuario.</param>
        /// <returns>Resultado del pedido ya calculado.</returns>
        public static ResultadoPedido EjecutarProceso(Pedido pedido)
        {
            return CalculoService.ProcesarPedido(pedido);
        }
    }
}
