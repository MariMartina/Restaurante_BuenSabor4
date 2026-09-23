using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Mesa
    {
        public int  Id { get; set; }
        public int IdNumero { get; set; }
        public int Capacidad { get; set; }
        public int IdUbicacion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public byte IdEstado { get; set; }  
    }
}
