using System.Collections.Generic;
using TiendaAvanzada.Models;
using TiendaAvanzada.UI;

namespace TiendaAvanzada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RegistroPedido> historial = new List<RegistroPedido>();
            ConsolaUI.MostrarMenuPrincipal(historial);
        }
    }
}
