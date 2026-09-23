using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class ReservaCliente
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public byte IdEstado { get; set; }
    }
}
