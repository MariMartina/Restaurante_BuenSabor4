
using System;
using System.Collections.Generic;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class CargoBL
    {
        public static int Guardar(Cargo pCargo)
        {
           
            if (string.IsNullOrEmpty(pCargo.Nombre))
                throw new Exception("El nombre del Cargo es obligatorio");

            return CargoDAL.Guardar(pCargo);
        }

        public static int Modificar(Cargo pCargo)
        {
            if (pCargo.Id == 0)
                throw new Exception("El Id del Cargo es obligatorio");

            return CargoDAL.Modificar(pCargo);
        }

        public static int Eliminar(Cargo pCargo)
        {
            return CargoDAL.Eliminar(pCargo);
        }

        public static  List<Cargo> ObtenerTodos()
        {
            return CargoDAL.ObtenerTodos();
        }

        public static   Cargo BuscarPorId(byte pId)
        {
            return CargoDAL.BuscarPorId(pId);
        }

        public static int ObtenerHabilitados()
        {
            return CargoDAL.ObtenerHabilitados(new Cargo());
        }
    }
}