
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class PedidoBL
    {
        public static string Guardar(Pedido pPedido)
        {
            if (pPedido.IdMesa == 0)
                return "Debe seleccionar una Mesa";
            if (pPedido.IdEmpleado == 0)
                return "Debe seleccionar un Empleado";
            if (pPedido.Total < 0)
                return "El Total no puede ser negativo";

            int resultado = PedidoDAL.Guardar(pPedido);
            return resultado > 0 ? "Pedido guardado correctamente" : "Error al guardar el pedido";
        }

        public static string Modificar(Pedido pPedido)
        {
            if (pPedido.IdMesa == 0)
                return "Debe seleccionar una Mesa";
            if (pPedido.IdEmpleado == 0)
                return "Debe seleccionar un Empleado";

            int resultado = PedidoDAL.Modificar(pPedido);
            return resultado > 0 ? "Pedido modificado correctamente" : "Error al modificar el pedido";
        }

        public static string Eliminar(Pedido pPedido)
        {
            int resultado = PedidoDAL.Eliminar(pPedido);
            return resultado > 0 ? "Pedido eliminado correctamente" : "Error al eliminar el pedido";
        }

        public static List<Pedido> ObtenerTodos()
        {
            return PedidoDAL.ObtenerTodos();
        }

        public static Pedido BuscarPorId(int pId)
        {
            return PedidoDAL.BuscarPorId(pId);
        }

        public static List<Pedido> ObtenerHabilitados()
        {
            return PedidoDAL.ObtenerHabilitados();
        }
    }
}