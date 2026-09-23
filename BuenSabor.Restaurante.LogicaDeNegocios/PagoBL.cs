
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class PagoBL
    {
        public static string Guardar(Pago pPago)
        {
            if (pPago.IdPedido == 0)
                return "Debe seleccionar un Pedido";
            if (pPago.Monto <= 0)
                return "El Monto debe ser mayor a 0";
            if (pPago.IdTipoPago == 0)
                return "Debe seleccionar un Tipo de Pago";

            int resultado = PagoDAL.Guardar(pPago);
            return resultado > 0 ? "Pago guardado correctamente" : "Error al guardar el pago";
        }

        public static string Modificar(Pago pPago)
        {
            if (pPago.IdPedido == 0)
                return "Debe seleccionar un Pedido";
            if (pPago.Monto <= 0)
                return "El Monto debe ser mayor a 0";
            if (pPago.IdTipoPago == 0)
                return "Debe seleccionar un Tipo de Pago";

            int resultado = PagoDAL.Modificar(pPago);
            return resultado > 0 ? "Pago modificado correctamente" : "Error al modificar el pago";
        }

        public static string Eliminar(Pago pPago)
        {
            int resultado = PagoDAL.Eliminar(pPago);
            return resultado > 0 ? "Pago eliminado correctamente" : "Error al eliminar el pago";
        }

        public static List<Pago> ObtenerTodos()
        {
            return PagoDAL.ObtenerTodos();
        }

        public static Pago BuscarPorId(int pId)
        {
            return PagoDAL.BuscarPorId(pId);
        }

        public static List<Pago> ObtenerHabilitados()
        {
            return PagoDAL.ObtenerHabilitados();
        }
    }
}