using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class UbicacionMesaBL
    {
        private UbicacionMesaDAL _dal = new UbicacionMesaDAL();

        public bool Guardar(UbicacionMesa ubicacion)
        {
            if (string.IsNullOrWhiteSpace(ubicacion.Descripcion))
                throw new Exception("La descripción de la ubicación es obligatoria");

            return _dal.Guardar(ubicacion);
        }

        public bool Modificar(UbicacionMesa ubicacion)
        {
            if (ubicacion.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(ubicacion);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<UbicacionMesa> ObtenerTodos() => _dal.ObtenerTodos();
        public UbicacionMesa BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<UbicacionMesa> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}
