namespace Tienda_en_linea.Models
{
    public class ResultadoPedido
    {
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal CostoEnvio { get; set; }
        public decimal TotalFinal { get; set; }
        public string Mensaje { get; set; }
    }
}
