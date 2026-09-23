using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Distrito
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte IdMunicipio { get; set; }
        public byte IdEstado { get; set; }
        public object IdDepartamento { get; set; }
        public object Habilitado { get; set; }
    }
}
