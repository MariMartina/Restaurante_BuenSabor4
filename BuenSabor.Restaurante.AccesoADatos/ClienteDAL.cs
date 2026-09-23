using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;
namespace TuProyecto.DAL
{
    public class ClienteDAL
    {
        private string _connectionString = "tu_cadena_de_conexion";

        public bool Guardar(Cliente cliente)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Cliente (Nombre, Telefono, Correo, Direccion, Habilitado) VALUES (@Nom, @Tel, @Cor, @Dir, @Hab)";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Nom", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Tel", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Cor", cliente.Email);
                cmd.Parameters.AddWithValue("@Dir", cliente.Direccion);
            
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Modificar(Cliente cliente) 
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Cliente SET Nombre=@Nom, Telefono=@Tel, Correo=@Cor, Direccion=@Dir, Habilitado=@Hab WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Nom", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Tel", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Cor", cliente.Email);
                cmd.Parameters.AddWithValue("@Dir", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Cliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            var lista = new List<Cliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cliente ORDER BY Nombre";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        
                    });
                }
            }
            return lista;
        }

        public Cliente BuscarPorId(int id) 
        {
            Cliente cliente = null;
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cliente WHERE Id=@Id";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente = new Cliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        
                    };
                }
            }
            return cliente;
        }

        public List<Cliente> ObtenerHabilitados()
        {
            var lista = new List<Cliente>();
            using (var cn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cliente WHERE Habilitado = 1 ORDER BY Nombre";
                var cmd = new SqlCommand(sql, cn);
                cn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                        Email = dr["Email"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        
                    });
                }
            }
            return lista;
        }
    }
}