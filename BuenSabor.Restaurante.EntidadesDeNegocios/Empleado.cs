using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int IdCargo { get; set; }
        public int IdSalario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoCargo { get; set; } = string.Empty;
        public byte IdEstado {  get; set; }
    }
}
