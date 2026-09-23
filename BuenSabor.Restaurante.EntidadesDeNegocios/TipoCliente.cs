using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class TipoCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descipcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public byte IdEstado { get; set; } 
    }
}
