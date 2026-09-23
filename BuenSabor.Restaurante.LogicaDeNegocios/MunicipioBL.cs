using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class MunicipioBL
    {
        private MunicipioDAL _dal = new MunicipioDAL();

        public bool Guardar(Municipio municipio)
        {
            if (string.IsNullOrWhiteSpace(municipio.Nombre))
                throw new Exception("El nombre del municipio es obligatorio");
            if (municipio.IdDepartamento <= 0)
                throw new Exception("Debe seleccionar un departamento");

            return _dal.Guardar(municipio);
        }

        public bool Modificar(Municipio municipio)
        {
            if (municipio.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(municipio);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Municipio> ObtenerTodos() => _dal.ObtenerTodos();
        public Municipio BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Municipio> ObtenerHabilitados() => _dal.ObtenerHabilitados();
        public List<Municipio> ObtenerPorDepartamento(int idDepartamento) => _dal.ObtenerPorDepartamento(idDepartamento);
    }
}