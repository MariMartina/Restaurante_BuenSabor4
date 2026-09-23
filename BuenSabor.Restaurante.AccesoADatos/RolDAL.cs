using System;
using System.Collections.Generic;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class RolDAL
    {
        public static int Crear(Rol p)
        {
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "INSERT INTO Rol(NombreRol) VALUES(@NombreRol); SELECT SCOPE_IDENTITY()";
            cmd.Parameters.AddWithValue("@NombreRol", p.NombreRol);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }
        public static int Modificar(Rol p)
        {
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "UPDATE Rol SET NombreRol=@NombreRol WHERE IdRol=@IdRol";
            cmd.Parameters.AddWithValue("@NombreRol", p.NombreRol);
            cmd.Parameters.AddWithValue("@IdRol", p.IdRol);
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return r;
        }
        public static int Eliminar(int id)
        {
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "DELETE FROM Rol WHERE IdRol=@IdRol";
            cmd.Parameters.AddWithValue("@IdRol", id);
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return r;
        }
        public static int Eliminar(Rol p)
        {
            return Eliminar(p.IdRol);

        }
        public static List<Rol> ObtenerTodos()
        {
            var lista = new List<Rol>();
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "SELECT IdRol, NombreRol FROM Rol";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Rol { IdRol = Convert.ToInt32(reader["IdRol"]), NombreRol = reader["NombreRol"].ToString() });
            }
            cmd.Connection.Close();
            return lista;
        }
        public static List<Rol> Buscar(Rol p)
        {
            var lista = new List<Rol>();
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "SELECT IdRol, NombreRol FROM Rol WHERE NombreRol LIKE @NombreRol";
            cmd.Parameters.AddWithValue("@NombreRol", "%" + p.NombreRol + "%");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Rol { IdRol = Convert.ToInt32(reader["IdRol"]), NombreRol = reader["NombreRol"].ToString() });
            }
            cmd.Connection.Close();
            return lista;
        }
        public static Rol ObtenerPorId(int id)
        {
            var cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "SELECT IdRol, NombreRol FROM Rol WHERE IdRol=@IdRol";
            cmd.Parameters.AddWithValue("@IdRol", id);
            var reader = cmd.ExecuteReader();
            Rol r = null;
            if (reader.Read())
            {
                r = new Rol { IdRol = Convert.ToInt32(reader["IdRol"]), NombreRol = reader["NombreRol"].ToString() };
            }
            cmd.Connection.Close();
            return r;
        }
    }
}