
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class PagoDAL
    {
        public static int Guardar(Pago pPago)
        {
            string consulta = "INSERT INTO Pago(IdPedido, Monto, FechaPago, IdTipoPago, IdEstado) VALUES(@IdPedido, @Monto, @FechaPago, @IdTipoPago, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdPedido", pPago.IdPedido);
            comando.Parameters.AddWithValue("@Monto", pPago.Monto);
            comando.Parameters.AddWithValue("@FechaPago", pPago.FechaPago);
            comando.Parameters.AddWithValue("@IdTipoPago", pPago.IdTipoPago);
            comando.Parameters.AddWithValue("@IdEstado", pPago.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Pago pPago)
        {
            string consulta = "UPDATE Pago SET IdPedido=@IdPedido, Monto=@Monto, FechaPago=@FechaPago, IdTipoPago=@IdTipoPago, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pPago.Id);
            comando.Parameters.AddWithValue("@IdPedido", pPago.IdPedido);
            comando.Parameters.AddWithValue("@Monto", pPago.Monto);
            comando.Parameters.AddWithValue("@FechaPago", pPago.FechaPago);
            comando.Parameters.AddWithValue("@IdTipoPago", pPago.IdTipoPago);
            comando.Parameters.AddWithValue("@IdEstado", pPago.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Pago pPago)
        {
            string consulta = "DELETE FROM Pago WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pPago.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<Pago> ObtenerTodos()
        {
            List<Pago> lista = new List<Pago>();
            string consulta = "SELECT Id, IdPedido, Monto, FechaPago, IdTipoPago, IdEstado FROM Pago";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pago pago = new Pago();
                    pago.Id = Convert.ToInt32(reader["Id"]);
                    pago.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                    pago.Monto = Convert.ToDecimal(reader["Monto"]);
                    pago.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
                    pago.IdTipoPago = Convert.ToByte(reader["IdTipoPago"]);
                    pago.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(pago);
                }
            }
            return lista;
        }

        public static Pago BuscarPorId(int pId)
        {
            Pago pago = null;
            string consulta = "SELECT Id, IdPedido, Monto, FechaPago, IdTipoPago, IdEstado FROM Pago WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    pago = new Pago();
                    pago.Id = Convert.ToInt32(reader["Id"]);
                    pago.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                    pago.Monto = Convert.ToDecimal(reader["Monto"]);
                    pago.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
                    pago.IdTipoPago = Convert.ToByte(reader["IdTipoPago"]);
                    pago.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return pago;
        }

        public static List<Pago> ObtenerHabilitados()
        {
            List<Pago> lista = new List<Pago>();
            string consulta = "SELECT Id, IdPedido, Monto, FechaPago, IdTipoPago, IdEstado FROM Pago WHERE IdEstado = 1"; 
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pago pago = new Pago();
                    pago.Id = Convert.ToInt32(reader["Id"]);
                    pago.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                    pago.Monto = Convert.ToDecimal(reader["Monto"]);
                    pago.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
                    pago.IdTipoPago = Convert.ToByte(reader["IdTipoPago"]);
                    pago.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(pago);
                }
            }
            return lista;
        }
    }
}