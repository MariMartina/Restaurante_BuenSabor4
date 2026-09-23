using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class DepartamentoBL
    {
        private DepartamentoDAL _dal = new DepartamentoDAL();

        public bool Guardar(Departamento departamento)
        {
            if (string.IsNullOrWhiteSpace(departamento.Nombre))
                throw new Exception("El nombre del departamento es obligatorio");

            return _dal.Guardar(departamento);
        }

        public bool Modificar(Departamento departamento)
        {
            if (departamento.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(departamento);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Departamento> ObtenerTodos() => _dal.ObtenerTodos();
        public Departamento BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Departamento> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}