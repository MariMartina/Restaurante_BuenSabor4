using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class TipoClienteBL
    {
        private TipoClienteDAL _dal = new TipoClienteDAL();

        public bool Guardar(TipoCliente tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                throw new Exception("La descripción es obligatoria");
            if (tipo.Descuento < 0 || tipo.Descuento > 1)
                throw new Exception("El descuento debe estar entre 0 y 1");

            return _dal.Guardar(tipo);
        }

        public bool Modificar(TipoCliente tipo)
        {
            if (tipo.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(tipo);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<TipoCliente> ObtenerTodo() => _dal.ObtenerTodo();
        public TipoCliente BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<TipoCliente> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}
