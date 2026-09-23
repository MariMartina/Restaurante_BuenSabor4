using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TuProyecto.Entidades;

namespace TuProyecto.DAL
{
    public class UbicacionMesaDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(UbicacionMesa ubicacion)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO UbicacionMesa (Descripcion, Habilitado) VALUES (@Desc, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Desc", ubicacion.Descripcion);
                cmd.Parameters.AddWithValue("@Hab", ubicacion.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(UbicacionMesa ubicacion)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE UbicacionMesa SET Descripcion=@Desc, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Desc", ubicacion.Descripcion);
                cmd.Parameters.AddWithValue("@Hab", ubicacion.Habilitado);
                cmd.Parameters.AddWithValue("@Id", ubicacion.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM UbicacionMesa WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<UbicacionMesa> ObtenerTodos()
        {
            var lista = new List<UbicacionMesa>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM UbicacionMesa";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new UbicacionMesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public UbicacionMesa BuscarPorId(int id) 
        {
            UbicacionMesa ubicacion = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM UbicacionMesa WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ubicacion = new UbicacionMesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return ubicacion;
        }

        public List<UbicacionMesa> ObtenerHabilitados()
        {
            var lista = new List<UbicacionMesa>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM UbicacionMesa WHERE Habilitado = 1 ORDER BY Descripcion";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new UbicacionMesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}