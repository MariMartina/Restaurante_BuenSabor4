using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;
namespace TuProyecto.DAL
{
    public class MesasDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(Mesa mesa)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Mesas (Numero, Capacidad, Habilitado) VALUES (@Num, @Cap, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Num", mesa.Numero);
                cmd.Parameters.AddWithValue("@Cap", mesa.Capacidad);
                cmd.Parameters.AddWithValue("@Hab", mesa.Habilitado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(Mesa mesa)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Mesas SET Numero=@Num, Capacidad=@Cap, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Num", mesa.Numero);
                cmd.Parameters.AddWithValue("@Cap", mesa.Capacidad);
                cmd.Parameters.AddWithValue("@Hab", mesa.Habilitado);
                cmd.Parameters.AddWithValue("@Id", mesa.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Mesas WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Mesa> ObtenerTodos()
        {
            var lista = new List<Mesa>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Mesas";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Mesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Numero = Convert.ToInt32(dr["Numero"]),
                        Capacidad = Convert.ToInt32(dr["Capacidad"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }

        public Mesa BuscarPorId(int id) 
        {
            Mesa mesa = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Mesas WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mesa = new Mesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Numero = Convert.ToInt32(dr["Numero"]),
                        Capacidad = Convert.ToInt32(dr["Capacidad"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    };
                }
            }
            return mesa;
        }

        public List<Mesa> ObtenerHabilitados()
        {
            var lista = new List<Mesa>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Mesas WHERE Habilitado = 1 ORDER BY Numero";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Mesa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Numero = Convert.ToInt32(dr["Numero"]),
                        Capacidad = Convert.ToInt32(dr["Capacidad"]),
                        Habilitado = Convert.ToBoolean(dr["Habilitado"])
                    });
                }
            }
            return lista;
        }
    }
}
