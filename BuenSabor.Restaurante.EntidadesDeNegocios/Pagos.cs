using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Pagos
    {
        public int IdPago { get; set; } 
        public int IdPedido { get; set; }
        public string IdMetodoPago { get; set; } = string.Empty;
        public decimal MontoPago { get; set; }  
        public DateTime FechaPago { get; set; }
        public string IdEstadoPago { get; set; } = string.Empty;
        public int Referencial {  get; set; }
        public byte IdEstado {  get; set; }
    }
}
