using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class ClienteTipoBL
    {
        private ClienteTipoDAL _dal = new ClienteTipoDAL();

        public bool Guardar(ClienteTipo tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                throw new Exception("La descripción del tipo de cliente es obligatoria");
            if (tipo.Descuento < 0 || tipo.Descuento > 1)
                throw new Exception("El descuento debe estar entre 0 y 1. Ej: 0.10 = 10%");

            return _dal.Guardar(tipo);
        }

        public bool Modificar(ClienteTipo tipo)
        {
            if (tipo.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(tipo);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<ClienteTipo> ObtenerTodo() => _dal.ObtenerTodo();
        public ClienteTipo BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<ClienteTipo> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}
