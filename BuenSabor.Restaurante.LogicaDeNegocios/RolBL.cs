using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class RolBL
    {
        public static int Crear(Rol p) { return RolDAL.Crear(p); }
        public static int Modificar(Rol p) { return RolDAL.Modificar(p); }
        public static int Eliminar(int id) { return RolDAL.Eliminar(id); }
        public static int Eliminar(Rol p) { return RolDAL.Eliminar(p.IdRol); }
        public static List<Rol> ObtenerTodos() { return RolDAL.ObtenerTodos(); }
        public static List<Rol> Buscar(Rol p) { return RolDAL.Buscar(p); }
        public static Rol ObtenerPorId(int id) { return RolDAL.ObtenerPorId(id); }
    }
}