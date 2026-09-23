using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class EstadoBL 
    
    {
        public static int Guardar(Estado pEstado) 
        {
            return EstadoDAL.Guardar(pEstado);

        }
        public static int Modificar(Estado pEstado) 
        {
            return EstadoDAL.Modificar(pEstado);
        
        }
        public static int Eliminar(Estado pEstado) 
        {
            return EstadoDAL.Eliminar(pEstado);

        }
        public static List<Estado> ObtenerTodos()
        {
            return EstadoDAL.ObtenerTodos();
         
        }
        public static Estado BuscarPorId(byte pId) 
        {
            return EstadoDAL.BuscarPorId(pId);
            
        }
        public static int ObtenerHabilitados(Estado pEstado) 
        {
        
            return EstadoDAL.ObtenerHabilitados(pEstado);

        
        }
    }
}
