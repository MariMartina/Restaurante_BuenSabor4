using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class ReservacionBL
    {
        private ReservacionDAL _dal = new ReservacionDAL();

        public bool Guardar(Reservacion res)
        {
            if (res.IdMesa <= 0)
                throw new Exception("Debe seleccionar una mesa");
            if (res.IdCliente <= 0)
                throw new Exception("Debe seleccionar un cliente");
            if (res.FechaReserva < DateTime.Today)
                throw new Exception("La fecha de reserva no puede ser anterior a hoy");
            if (res.CantidadPersonas <= 0)
                throw new Exception("La cantidad de personas debe ser mayor a 0");

            return _dal.Guardar(res);
        }

        public bool Modificar(Reservacion res)
        {
            if (res.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(res);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Reservacion> ObtenerTodos() => _dal.ObtenerTodos();
        public Reservacion BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Reservacion> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}