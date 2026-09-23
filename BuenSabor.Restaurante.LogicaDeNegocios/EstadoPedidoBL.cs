
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class EstadoPedidoBL
    {
        public static string Guardar(EstadoPedido pEstadoPedido)
        {
            if (string.IsNullOrEmpty(pEstadoPedido.Nombre))
                return "El Nombre del EstadoPedido es obligatorio";

            int resultado = EstadoPedidoDAL.Guardar(pEstadoPedido);
            return resultado > 0 ? "EstadoPedido guardado correctamente" : "Error al guardar";
        }

        public static string Modificar(EstadoPedido pEstadoPedido)
        {
            if (string.IsNullOrEmpty(pEstadoPedido.Nombre))
                return "El Nombre del EstadoPedido es obligatorio";

            int resultado = EstadoPedidoDAL.Modificar(pEstadoPedido);
            return resultado > 0 ? "EstadoPedido modificado correctamente" : "Error al modificar";
        }

        public static string Eliminar(EstadoPedido pEstadoPedido)
        {
            int resultado = EstadoPedidoDAL.Eliminar(pEstadoPedido);
            return resultado > 0 ? "EstadoPedido eliminado correctamente" : "Error al eliminar";
        }

        public static List<EstadoPedido> ObtenerTodos()
        {
            return EstadoPedidoDAL.ObtenerTodos();
        }

        public static EstadoPedido BuscarPorId(byte pId)
        {
            return EstadoPedidoDAL.BuscarPorId(pId);
        }

        public static List<EstadoPedido> ObtenerHabilitados()
        {
            return EstadoPedidoDAL.ObtenerHabilitados();
        }
    }
}