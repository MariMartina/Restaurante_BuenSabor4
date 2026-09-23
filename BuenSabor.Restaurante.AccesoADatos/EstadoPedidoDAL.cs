using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EstadoPedidoDAL
    {
        public static int Guardar(EstadoPedido pEstadoPedido)
        {
            string consulta = "INSERT INTO EstadoPedido(Nombre, IdEstado) VALUES(@Nombre, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pEstadoPedido.Nombre);
            comando.Parameters.AddWithValue("@IdEstado", pEstadoPedido.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(EstadoPedido pEstadoPedido)
        {
            string consulta = "UPDATE EstadoPedido SET Nombre=@Nombre, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstadoPedido.Id);
            comando.Parameters.AddWithValue("@Nombre", pEstadoPedido.Nombre);
            comando.Parameters.AddWithValue("@IdEstado", pEstadoPedido.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(EstadoPedido pEstadoPedido)
        {
            string consulta = "DELETE FROM EstadoPedido WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstadoPedido.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<EstadoPedido> ObtenerTodos()
        {
            List<EstadoPedido> lista = new List<EstadoPedido>();
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoPedido";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EstadoPedido ep = new EstadoPedido();
                    ep.Id = Convert.ToByte(reader["Id"]);
                    ep.Nombre = reader["Nombre"].ToString();
                    ep.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(ep);
                }
            }
            return lista;
        }

        public static EstadoPedido BuscarPorId(byte pId)
        {
            EstadoPedido ep = null;
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoPedido WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    ep = new EstadoPedido();
                    ep.Id = Convert.ToByte(reader["Id"]);
                    ep.Nombre = reader["Nombre"].ToString();
                    ep.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return ep;
        }

        public static List<EstadoPedido> ObtenerHabilitados()
        {
            List<EstadoPedido> lista = new List<EstadoPedido>();
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoPedido WHERE IdEstado = 1"; 
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EstadoPedido ep = new EstadoPedido();
                    ep.Id = Convert.ToByte(reader["Id"]);
                    ep.Nombre = reader["Nombre"].ToString();
                    ep.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(ep);
                }
            }
            return lista;
        }
    }
}