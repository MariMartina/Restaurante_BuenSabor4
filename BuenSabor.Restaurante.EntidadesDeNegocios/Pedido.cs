using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaPedido { get; set; }
        public TimeSpan HoraPedido { get; set; } 
        public int IdEstadoPedido { get; set; }
        public decimal TotalPagar { get; set; } 
        public int IdReservacion {  get; set; }
        public byte IdEstado {  get; set; }
    }
}
