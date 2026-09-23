using BuenSabor.Restaurante.EntidadesDeNegocios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TuProyecto.Entidades;

namespace TuProyecto.DAL
{
    public class MunicipioDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(Municipio municipio)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Municipio (Nombre, IdDepartamento, Habilitado) VALUES (@Nom, @IdDep, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Nom", municipio.Nombre);
                cmd.Parameters.AddWithValue("@IdDep", municipio.IdDepartamento);
                cmd.Parameters.AddWithValue("@Hab", municipio.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(Municipio municipio)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Municipio SET Nombre=@Nom, IdDepartamento=@IdDep, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Nom", municipio.Nombre);
                cmd.Parameters.AddWithValue("@IdDep", municipio.IdDepartamento);
                cmd.Parameters.AddWithValue("@Hab", municipio.Habilitado);
                cmd.Parameters.AddWithValue("@Id", municipio.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Municipio WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Municipio> ObtenerTodos()
        {
            var lista = new List<Municipio>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Municipio ORDER BY Nombre";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Municipio
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public Municipio BuscarPorId(int id)
        {
            Municipio municipio = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Municipio WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    municipio = new Municipio
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return municipio;
        }

        public List<Municipio> ObtenerHabilitados()
        {
            var lista = new List<Municipio>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Municipio WHERE Habilitado = 1 ORDER BY Nombre";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Municipio
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        
        public List<Municipio> ObtenerPorDepartamento(int idDepartamento)
        {
            var lista = new List<Municipio>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Municipio WHERE IdDepartamento=@IdDep AND Habilitado=1 ORDER BY Nombre";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdDep", idDepartamento);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Municipio
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}
