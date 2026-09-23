using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using TuProyecto.DAL;
using TuProyecto.Entidades;

namespace TuProyecto.BL
{
    public class MenuBL
    {
        MenuDAL dal = new MenuDAL();

        public bool Guardar(Menu m)
        {
            if (string.IsNullOrEmpty(m.Nombre))
                throw new Exception("Nombre obligatorio");
            return dal.Guardar(m);
        }

        public bool Modificar(Menu m)
        {
            if (m.Id <= 0)
                throw new Exception("Id invalido");
            return dal.Modificar(m);
        }

        public bool Eliminar(int id) => dal.Eliminar(id);
        public List<Menu> ObtenerTodos() => dal.ObtenerTodos();
        public Menu BuscarPorId(int id) => dal.BuscarPorId(id);
        public List<Menu> ObtenerHabilitados() => dal.ObtenerHabilitados();
    }
}
