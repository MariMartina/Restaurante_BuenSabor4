
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class EstadoCargoBL
    {
        public static string Guardar(EstadoCargo pEstadoCargo)
        {
            if (string.IsNullOrEmpty(pEstadoCargo.Nombre))
                return "El Nombre es obligatorio";

            int resultado = EstadoCargoDAL.Guardar(pEstadoCargo);
            return resultado > 0 ? "EstadoCargo guardado correctamente" : "Error al guardar";
        }

        public static string Modificar(EstadoCargo pEstadoCargo)
        {
            if (string.IsNullOrEmpty(pEstadoCargo.Nombre))
                return "El Nombre es obligatorio";

            int resultado = EstadoCargoDAL.Modificar(pEstadoCargo);
            return resultado > 0 ? "EstadoCargo modificado correctamente" : "Error al modificar";
        }

        public static string Eliminar(EstadoCargo pEstadoCargo)
        {
            int resultado = EstadoCargoDAL.Eliminar(pEstadoCargo);
            return resultado > 0 ? "EstadoCargo eliminado correctamente" : "Error al eliminar";
        }

        public static List<EstadoCargo> ObtenerTodos()
        {
            return EstadoCargoDAL.ObtenerTodos();
        }

        public static EstadoCargo BuscarPorId(byte pId)
        {
            return EstadoCargoDAL.BuscarPorId(pId);
        }

        public static List<EstadoCargo> ObtenerHabilitados()
        {
            return EstadoCargoDAL.ObtenerHabilitados();
        }
    }
}