namespace Tienda_en_linea.Models
{
    public class Pedido
    {
        public string NombreCliente { get; set; }
        public decimal TotalCompra { get; set; }
        public int CantidadProductos { get; set; }
        public bool EsClienteFrecuente { get; set; }
        public bool TieneCupon { get; set; }
    }
}
