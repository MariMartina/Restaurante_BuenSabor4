using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class EstadoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte IdEstado { get; set; }
        public object Descripcion { get; set; }
        public object Habilitado { get; set; }
    }
}
