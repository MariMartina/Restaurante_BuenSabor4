using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL; 
using TuProyecto.Entidades; 

namespace TuProyecto.BL
{
    public class EstadoPagoBL
    {
        private EstadoPagoDAL _dal = new EstadoPagoDAL();

        public bool Guardar(EstadoPago estado)
        {
            if (string.IsNullOrEmpty(estado.Descripcion))
                throw new Exception("La descripción es obligatoria");

            return _dal.Guardar(estado);
        }

        public bool Modificar(EstadoPago estado)
        {
            if (estado.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(estado);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<EstadoPago> ObtenerTodos() => _dal.ObtenerTodos();
        public EstadoPago BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<EstadoPago> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}