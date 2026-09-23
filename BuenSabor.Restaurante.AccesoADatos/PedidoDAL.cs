
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class PedidoDAL
    {
        public static int Guardar(Pedido pPedido)
        {
            string consulta = "INSERT INTO Pedido(IdMesa, IdEmpleado, Fecha, Total, IdEstado) VALUES(@IdMesa, @IdEmpleado, @Fecha, @Total, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdMesa", pPedido.IdMesa);
            comando.Parameters.AddWithValue("@IdEmpleado", pPedido.IdEmpleado);
            comando.Parameters.AddWithValue("@Fecha", pPedido.Fecha);
            comando.Parameters.AddWithValue("@Total", pPedido.Total);
            comando.Parameters.AddWithValue("@IdEstado", pPedido.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Pedido pPedido)
        {
            string consulta = "UPDATE Pedido SET IdMesa=@IdMesa, IdEmpleado=@IdEmpleado, Fecha=@Fecha, Total=@Total, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pPedido.Id);
            comando.Parameters.AddWithValue("@IdMesa", pPedido.IdMesa);
            comando.Parameters.AddWithValue("@IdEmpleado", pPedido.IdEmpleado);
            comando.Parameters.AddWithValue("@Fecha", pPedido.Fecha);
            comando.Parameters.AddWithValue("@Total", pPedido.Total);
            comando.Parameters.AddWithValue("@IdEstado", pPedido.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Pedido pPedido)
        {
            string consulta = "DELETE FROM Pedido WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pPedido.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<Pedido> ObtenerTodos()
        {
            List<Pedido> lista = new List<Pedido>();
            string consulta = "SELECT Id, IdMesa, IdEmpleado, Fecha, Total, IdEstado FROM Pedido ORDER BY Fecha DESC";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = Convert.ToInt32(reader["Id"]);
                    pedido.IdMesa = Convert.ToByte(reader["IdMesa"]);
                    pedido.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    pedido.Total = Convert.ToDecimal(reader["Total"]);
                    pedido.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(pedido);
                }
            }
            return lista;
        }

        public static Pedido BuscarPorId(int pId)
        {
            Pedido pedido = null;
            string consulta = "SELECT Id, IdMesa, IdEmpleado, Fecha, Total, IdEstado FROM Pedido WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    pedido = new Pedido();
                    pedido.Id = Convert.ToInt32(reader["Id"]);
                    pedido.IdMesa = Convert.ToByte(reader["IdMesa"]);
                    pedido.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    pedido.Total = Convert.ToDecimal(reader["Total"]);
                    pedido.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return pedido;
        }

        public static List<Pedido> ObtenerHabilitados()
        {
            List<Pedido> lista = new List<Pedido>();
            string consulta = "SELECT Id, IdMesa, IdEmpleado, Fecha, Total, IdEstado FROM Pedido WHERE IdEstado = 1 ORDER BY Fecha DESC"; 
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = Convert.ToInt32(reader["Id"]);
                    pedido.IdMesa = Convert.ToByte(reader["IdMesa"]);
                    pedido.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    pedido.Total = Convert.ToDecimal(reader["Total"]);
                    pedido.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(pedido);
                }
            }
            return lista;
        }
    }
}