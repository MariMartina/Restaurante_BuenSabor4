using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }    
        public byte IdEstado { get; set; }
        public object Url { get; set; }
        public object Icono { get; set; }
        public object IdMenuPadre { get; set; }
        public object Orden { get; set; }
        public object Habilitado { get; set; }
    }
}
