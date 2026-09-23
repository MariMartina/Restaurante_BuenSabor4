using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TuProyecto.Entidades;

namespace TuProyecto.DAL
{
    public class ReservacionDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(Reservacion res)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Reservacion (IdMesa, IdCliente, FechaReserva, Hora, CantidadPersonas, Estado, Habilitado) 
                               VALUES (@IdMesa, @IdCliente, @Fecha, @Hora, @Cant, @Estado, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdMesa", res.IdMesa);
                cmd.Parameters.AddWithValue("@IdCliente", res.IdCliente);
                cmd.Parameters.AddWithValue("@Fecha", res.FechaReserva);
                cmd.Parameters.AddWithValue("@Hora", res.Hora);
                cmd.Parameters.AddWithValue("@Cant", res.CantidadPersonas);
                cmd.Parameters.AddWithValue("@Estado", res.Estado);
                cmd.Parameters.AddWithValue("@Hab", res.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(Reservacion res)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Reservacion SET IdMesa=@IdMesa, IdCliente=@IdCliente, FechaReserva=@Fecha, 
                               Hora=@Hora, CantidadPersonas=@Cant, Estado=@Estado, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdMesa", res.IdMesa);
                cmd.Parameters.AddWithValue("@IdCliente", res.IdCliente);
                cmd.Parameters.AddWithValue("@Fecha", res.FechaReserva);
                cmd.Parameters.AddWithValue("@Hora", res.Hora);
                cmd.Parameters.AddWithValue("@Cant", res.CantidadPersonas);
                cmd.Parameters.AddWithValue("@Estado", res.Estado);
                cmd.Parameters.AddWithValue("@Hab", res.Habilitado);
                cmd.Parameters.AddWithValue("@Id", res.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Reservacion WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Reservacion> ObtenerTodos()
        {
            var lista = new List<Reservacion>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Reservacion ORDER BY FechaReserva DESC, Hora DESC";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Reservacion
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdMesa = Convert.ToInt32(dr["IdMesa"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        FechaReserva = Convert.ToDateTime(dr["FechaReserva"]),
                        Hora = (TimeSpan)dr["Hora"],
                        CantidadPersonas = Convert.ToInt32(dr["CantidadPersonas"]),
                        Estado = dr["Estado"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public Reservacion BuscarPorId(int id)
        {
            Reservacion res = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Reservacion WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    res = new Reservacion
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdMesa = Convert.ToInt32(dr["IdMesa"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        FechaReserva = Convert.ToDateTime(dr["FechaReserva"]),
                        Hora = (TimeSpan)dr["Hora"],
                        CantidadPersonas = Convert.ToInt32(dr["CantidadPersonas"]),
                        Estado = dr["Estado"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return res;
        }

        public List<Reservacion> ObtenerHabilitados()
        {
            var lista = new List<Reservacion>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Reservacion WHERE Habilitado = 1 ORDER BY FechaReserva, Hora";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Reservacion
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdMesa = Convert.ToInt32(dr["IdMesa"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        FechaReserva = Convert.ToDateTime(dr["FechaReserva"]),
                        Hora = (TimeSpan)dr["Hora"],
                        CantidadPersonas = Convert.ToInt32(dr["CantidadPersonas"]),
                        Estado = dr["Estado"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}