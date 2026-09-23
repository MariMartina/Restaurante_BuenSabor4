
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class EmpleadoBL
    {
        public static string Guardar(Empleado pEmpleado)
        {
            if (string.IsNullOrEmpty(pEmpleado.Nombres))
                return "El Nombre es obligatorio";
            if (string.IsNullOrEmpty(pEmpleado.Apellidos))
                return "El Apellido es obligatorio";
            if (string.IsNullOrEmpty(pEmpleado.Dui))
                return "El DUI es obligatorio";
            if (pEmpleado.IdCargo == 0)
                return "Debe seleccionar un Cargo";

            int resultado = EmpleadoDAL.Guardar(pEmpleado);
            return resultado > 0 ? "Empleado guardado correctamente" : "Error al guardar el empleado";
        }

        public static string Modificar(Empleado pEmpleado)
        {
            if (string.IsNullOrEmpty(pEmpleado.Nombres))
                return "El Nombre es obligatorio";
            if (string.IsNullOrEmpty(pEmpleado.Apellidos))
                return "El Apellido es obligatorio";
            if (string.IsNullOrEmpty(pEmpleado.Dui))
                return "El DUI es obligatorio";
            if (pEmpleado.IdCargo == 0)
                return "Debe seleccionar un Cargo";

            int resultado = EmpleadoDAL.Modificar(pEmpleado);
            return resultado > 0 ? "Empleado modificado correctamente" : "Error al modificar el empleado";
        }

        public static string Eliminar(Empleado pEmpleado)
        {
            int resultado = EmpleadoDAL.Eliminar(pEmpleado);
            return resultado > 0 ? "Empleado eliminado correctamente" : "Error al eliminar el empleado";
        }

        public static List<Empleado> ObtenerTodos()
        {
            return EmpleadoDAL.ObtenerTodos();
        }

        public static Empleado BuscarPorId(int pId)
        {
            return EmpleadoDAL.BuscarPorId(pId);
        }

        public static List<Empleado> ObtenerHabilitados()
        {
            return EmpleadoDAL.ObtenerHabilitados();
        }
    }
}