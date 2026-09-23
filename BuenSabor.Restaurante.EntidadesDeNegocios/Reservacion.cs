using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public  class Reservacion
    {
        public int Id { get; set; } 
        public int IdCliente { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Hora {  get; set; }   = string.Empty;
        public int NumeroPersonal { get; set; }
        public int IdMesas { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public byte IdEstado { get; set; }
    }
}
