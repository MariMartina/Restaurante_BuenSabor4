
using System;
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class EmpleadoTurnoBL
    {
        public static string Guardar(EmpleadoTurno pEmpleadoTurno)
        {
            if (pEmpleadoTurno.IdEmpleado == 0)
                return "Debe seleccionar un Empleado";
            if (pEmpleadoTurno.IdTurno == 0)
                return "Debe seleccionar un Turno";

            int resultado = EmpleadoTurnoDAL.Guardar(pEmpleadoTurno);
            return resultado > 0 ? "Asignación guardada correctamente" : "Error al guardar";
        }

        public static string Modificar(EmpleadoTurno pEmpleadoTurno)
        {
            int resultado = EmpleadoTurnoDAL.Modificar(pEmpleadoTurno);
            return resultado > 0 ? "Asignación modificada correctamente" : "Error al modificar";
        }

        public static string Eliminar(EmpleadoTurno pEmpleadoTurno)
        {
            int resultado = EmpleadoTurnoDAL.Eliminar(pEmpleadoTurno);
            return resultado > 0 ? "Asignación eliminada correctamente" : "Error al eliminar";
        }

        public static List<EmpleadoTurno> ObtenerTodos()
        {
            return EmpleadoTurnoDAL.ObtenerTodos();
        }

        public static EmpleadoTurno BuscarPorId(int pIdEmpleado, byte pIdTurno, DateTime pFecha)
        {
            return EmpleadoTurnoDAL.BuscarPorId(pIdEmpleado, pIdTurno, pFecha);
        }

        public static List<EmpleadoTurno> ObtenerHabilitados()
        {
            return EmpleadoTurnoDAL.ObtenerHabilitados();
        }
    }
}