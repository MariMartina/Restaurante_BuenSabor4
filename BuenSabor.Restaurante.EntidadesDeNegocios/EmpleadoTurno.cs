using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class EmpleadoTurno
    {
        public int Id { get; set; } 
        public int IdEmpleado { get; set; } 
        public int IdTurno { get; set; }
        public byte IdEstado { get; set; }
        public object Fecha { get; set; }
    }
}
