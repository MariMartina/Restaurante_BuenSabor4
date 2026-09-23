
using System;
using System.Collections.Generic;
using System.Linq;
using BuenSaborRestaurante.EntidadesDeNegocias;
using BuenSaborRestaurante.AccesoDatos;

namespace BuenSaborRestaurante.LogicaNegocio
{
    public class MetodoPagoBL
    {
        MetodoPagoDAL dal = new MetodoPagoDAL();

        public bool Guardar(MetodoPago pMetodoPago)
        {
            if (string.IsNullOrWhiteSpace(pMetodoPago.Nombre))
                throw new Exception("El nombre del método de pago es obligatorio");

            
            var existe = ObtenerTodos().Any(x => x.Nombre.ToLower() == pMetodoPago.Nombre.ToLower());
            if (existe)
                throw new Exception("Ya existe un método de pago con ese nombre");

            pMetodoPago.Habilitado = true; 
            return dal.Guardar(pMetodoPago);
        }

        public bool Modificar(MetodoPago pMetodoPago)
        {
            if (pMetodoPago.Id <= 0)
                throw new Exception("Id inválido");

            var actual = BuscarPorId(pMetodoPago.Id);
            if (actual == null)
                throw new Exception("El método de pago no existe");

            return dal.Modificar(pMetodoPago);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido");

            var actual = BuscarPorId(id);
            if (actual == null)
                throw new Exception("El método de pago no existe");

            
            return dal.Eliminar(id);
        }

        public List<MetodoPago> ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        public MetodoPago BuscarPorId(int id)
        {
            return dal.BuscarPorId(id);
        }

        public List<MetodoPago> ObtenerHabilitados()
        {
            return dal.ObtenerHabilitados();
        }
    }
}
