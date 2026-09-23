using System;
using System.Collections.Generic;
using System.Text;

namespace BuenSabor.Restaurante.EntidadesDeNegocios
{
    public class Cliente
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion {  get; set; }   = string.Empty;
        public byte IdDistrito { get; set; }
        public string Email {  get; set; }   = string.Empty;
        public byte IdEstado { get; set; }
    }
}
