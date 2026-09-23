using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class MesasBL
    {
        private MesasDAL _dal = new MesasDAL();

        public bool Guardar(Mesa mesa)
        {
            if (mesa.Numero <= 0)
                throw new Exception("El número de mesa debe ser mayor a 0");
            if (mesa.Capacidad <= 0)
                throw new Exception("La capacidad debe ser mayor a 0");

            return _dal.Guardar(mesa);
        }

        public bool Modificar(Mesa mesa)
        {
            if (mesa.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(mesa);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Mesa> ObtenerTodos() => _dal.ObtenerTodos();
        public Mesa BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Mesa> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}
