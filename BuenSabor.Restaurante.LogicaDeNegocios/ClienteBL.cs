using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class ClienteBL
    {
        private ClienteDAL _dal = new ClienteDAL();

        public bool Guardar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new Exception("El nombre del cliente es obligatorio");
            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new Exception("El teléfono es obligatorio");

            return _dal.Guardar(cliente);
        }

        public bool Modificar(Cliente cliente)
        {
            if (cliente.Id <= 0)
                throw new Exception("Id inválido");

            return _dal.Modificar(cliente);
        }

        public bool Eliminar(int id) => _dal.Eliminar(id);
        public List<Cliente> ObtenerTodos() => _dal.ObtenerTodos();
        public Cliente BuscarPorId(int id) => _dal.BuscarPorId(id);
        public List<Cliente> ObtenerHabilitados() => _dal.ObtenerHabilitados();
    }
}