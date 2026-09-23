using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class ReservaClienteBL
    {
        private ReservaClienteDAL _dal = new ReservaClienteDAL();

        public bool Guardar(ReservaCliente rc)
        {
            if (rc.IdReservacion <= 0)
                throw new Exception("Debe seleccionar una reservación");
            if (rc.IdCliente <= 0)
                throw new Exception("Debe seleccionar un cliente");

            return _dal.Guardar(rc);
        }

        public bool Modificar(ReservaCliente rc)
        {
            if (rc.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(rc);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<ReservaCliente> ObtenerTodos() => _dal.ObtenerTodos();
        public ReservaCliente BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<ReservaCliente> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}