using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Cargo
    {
        public int Id { get; set; }
        public int IdEstadoCargo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public byte IdEstado { get; set; }
    }
}
