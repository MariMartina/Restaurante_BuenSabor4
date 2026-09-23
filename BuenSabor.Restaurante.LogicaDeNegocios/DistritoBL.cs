using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class DistritoBL
    {
        private DistritoDAL _dal = new DistritoDAL();

        public bool Guardar(Distrito distrito)
        {
            if (string.IsNullOrWhiteSpace(distrito.Nombre))
                throw new Exception("El nombre del distrito es obligatorio");
            if (distrito.IdDepartamento <= 0)
                throw new Exception("Debe seleccionar un departamento");

            return _dal.Guardar(distrito);
        }

        public bool Modificar(Distrito distrito)
        {
            if (distrito.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(distrito);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Distrito> ObtenerTodos() => _dal.ObtenerTodos();
        public Distrito BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Distrito> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}
