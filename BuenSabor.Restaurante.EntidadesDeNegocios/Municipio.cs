using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Municipio
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte IdDepartamento { get; set; }
        public byte IdEstado { get; set; }
    }
}
