using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class ClienteTipo
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public byte IdEstado { get; set; }
        public object Descripcion { get; set; }
        public object Nombre { get; set; }
    }
}
