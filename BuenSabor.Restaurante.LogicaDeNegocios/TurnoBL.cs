
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class TurnoBL
    {
        public static string Guardar(Turno pTurno)
        {
            if (string.IsNullOrEmpty(pTurno.Nombre))
                return "El Nombre del turno es obligatorio";
            if (pTurno.HoraEntrada >= pTurno.HoraSalida)
                return "La Hora de Salida debe ser mayor a la de Entrada";

            int resultado = TurnoDAL.Guardar(pTurno);
            return resultado > 0 ? "Turno guardado correctamente" : "Error al guardar el turno";
        }

        public static string Modificar(Turno pTurno)
        {
            if (string.IsNullOrEmpty(pTurno.Nombre))
                return "El Nombre del turno es obligatorio";
            if (pTurno.HoraEntrada >= pTurno.HoraSalida)
                return "La Hora de Salida debe ser mayor a la de Entrada";

            int resultado = TurnoDAL.Modificar(pTurno);
            return resultado > 0 ? "Turno modificado correctamente" : "Error al modificar el turno";
        }

        public static string Eliminar(Turno pTurno)
        {
            int resultado = TurnoDAL.Eliminar(pTurno);
            return resultado > 0 ? "Turno eliminado correctamente" : "Error al eliminar el turno";
        }

        public static List<Turno> ObtenerTodos()
        {
            return TurnoDAL.ObtenerTodos();
        }

        public static Turno BuscarPorId(byte pId)
        {
            return TurnoDAL.BuscarPorId(pId);
        }

        public static List<Turno> ObtenerHabilitados()
        {
            return TurnoDAL.ObtenerHabilitados();
        }
    }
}