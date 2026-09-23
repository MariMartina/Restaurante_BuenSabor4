using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TuProyecto.Entidades;

namespace TuProyecto.DAL
{
    public class ReservaClienteDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(ReservaCliente rc)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO ReservaCliente (IdReservacion, IdCliente, Observaciones, Habilitado) VALUES (@IdRes, @IdCli, @Obs, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdRes", rc.IdReservacion);
                cmd.Parameters.AddWithValue("@IdCli", rc.IdCliente);
                cmd.Parameters.AddWithValue("@Obs", rc.Observaciones);
                cmd.Parameters.AddWithValue("@Hab", rc.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(ReservaCliente rc)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE ReservaCliente SET IdReservacion=@IdRes, IdCliente=@IdCli, Observaciones=@Obs, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdRes", rc.IdReservacion);
                cmd.Parameters.AddWithValue("@IdCli", rc.IdCliente);
                cmd.Parameters.AddWithValue("@Obs", rc.Observaciones);
                cmd.Parameters.AddWithValue("@Hab", rc.Habilitado);
                cmd.Parameters.AddWithValue("@Id", rc.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM ReservaCliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<ReservaCliente> ObtenerTodos()
        {
            var lista = new List<ReservaCliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM ReservaCliente";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ReservaCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdReservacion = Convert.ToInt32(dr["IdReservacion"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Observaciones = dr["Observaciones"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public ReservaCliente BuscarPorId(int id) 
        {
            ReservaCliente rc = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM ReservaCliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rc = new ReservaCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdReservacion = Convert.ToInt32(dr["IdReservacion"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Observaciones = dr["Observaciones"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return rc;
        }

        public List<ReservaCliente> ObtenerHabilitados()
        {
            var lista = new List<ReservaCliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM ReservaCliente WHERE Habilitado = 1";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ReservaCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdReservacion = Convert.ToInt32(dr["IdReservacion"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Observaciones = dr["Observaciones"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}