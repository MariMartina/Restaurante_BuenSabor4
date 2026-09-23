using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TuProyecto.Entidades;

namespace TuProyecto.DAL
{
    public class TipoClienteDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(TipoCliente tipo)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO TipoCliente (Descripcion, Descuento, Habilitado) VALUES (@Desc, @Descue, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Desc", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@Descue", tipo.Descuento);
                cmd.Parameters.AddWithValue("@Hab", tipo.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(TipoCliente tipo)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE TipoCliente SET Descripcion=@Desc, Descuento=@Descue, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Desc", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@Descue", tipo.Descuento);
                cmd.Parameters.AddWithValue("@Hab", tipo.Habilitado);
                cmd.Parameters.AddWithValue("@Id", tipo.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM TipoCliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<TipoCliente> ObtenerTodo()
        {
            var lista = new List<TipoCliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM TipoCliente ORDER BY Descripcion";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TipoCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public TipoCliente BuscarPorId(int id)
        {
            TipoCliente tipo = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM TipoCliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tipo = new TipoCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return tipo;
        }

        public List<TipoCliente> ObtenerHabilitados()
        {
            var lista = new List<TipoCliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM TipoCliente WHERE Habilitado = 1 ORDER BY Descripcion";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TipoCliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}