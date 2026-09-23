using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Departamento
    {
        public byte Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public byte IdDepartamento { get; set; }
        public byte IdEstado { get; set; }
        public object Habilitado { get; set; }
        public object Codigo { get; set; }
    }
}
