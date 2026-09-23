using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;


namespace BuenSabor.Restaurante.AccesoADatos
{
    public class CargoDAL
    {
        public static int Guardar(Cargo pCargo)
        {
            string consulta = "INSERT INTO Cargo(Nombre, Descripcion, IdEstado) VALUES(@Nombre, @Descripcion, @IdEstado)";
            SqlCommand Comando = ComunDB.ObtenerComando();
            Comando.CommandText = consulta;
            Comando.Parameters.AddWithValue("@Nombre", pCargo.Nombre);
            Comando.Parameters.AddWithValue("@Descripcion", pCargo.Descripcion);
            Comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            return ComunDB.EjecutarComando(Comando);
        }
        public static int Modificar(Cargo pCargo)
        {
            string consulta = "UPDATE Cargo SET Nombre=@Nombre, Descripcion=@Descripcion, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pCargo.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pCargo.Descripcion);
            comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            comando.Parameters.AddWithValue("@Id", pCargo.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Cargo pCargo)
        {
            string consulta = "DELETE FROM Cargo WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pCargo.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static List<Cargo> ObtenerTodos()
        {
            List<Cargo> lista = new List<Cargo>();
            string consulta = "SELECT Id, Nombre, Descripcion, IdEstado FROM Cargo";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cargo cargo = new Cargo();
                    cargo.Id = Convert.ToInt32(reader["Id"]);
                    cargo.Nombre = reader["Nombre"].ToString();
                    cargo.Descripcion = reader["Descripcion"].ToString();
                    cargo.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(cargo);
                }
            }
            return lista;
        }
        public static Cargo BuscarPorId(byte pId)
        {
            Cargo cargo = null;
            string consulta = "SELECT Id, Nombre, Descripcion, IdEstado FROM Cargo WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);

            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    cargo = new Cargo();
                    cargo.Id = Convert.ToInt32(reader["Id"]);
                    cargo.Nombre = reader["Nombre"].ToString();
                    cargo.Descripcion = reader["Descripcion"].ToString();
                    cargo.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return cargo;
        }

        public static int ObtenerHabilitados(Cargo pCargo)
        {
            int cantidad = 0;
            SqlCommand cmd = ComunDB.ObtenerComando();
            cmd.CommandText = "SELECT COUNT(*) FROM Cargo WHERE IdEstado = 1";
            using (cmd.Connection)
            {
                cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return cantidad;
        }
    }
}


