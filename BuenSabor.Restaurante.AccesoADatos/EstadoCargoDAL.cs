using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EstadoCargoDAL
    {
        public static int Guardar(EstadoCargo pEstadoCargo)
        {
            string consulta = "INSERT INTO EstadoCargo(Nombre, IdEstado) VALUES(@Nombre, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pEstadoCargo.Nombre);
            comando.Parameters.AddWithValue("@IdEstado", pEstadoCargo.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(EstadoCargo pEstadoCargo)
        {
            string consulta = "UPDATE EstadoCargo SET Nombre=@Nombre, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstadoCargo.Id);
            comando.Parameters.AddWithValue("@Nombre", pEstadoCargo.Nombre);
            comando.Parameters.AddWithValue("@IdEstado", pEstadoCargo.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(EstadoCargo pEstadoCargo)
        {
            string consulta = "DELETE FROM EstadoCargo WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstadoCargo.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<EstadoCargo> ObtenerTodos()
        {
            List<EstadoCargo> lista = new List<EstadoCargo>();
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoCargo";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EstadoCargo ec = new EstadoCargo();
                    ec.Id = Convert.ToByte(reader["Id"]);
                    ec.Nombre = reader["Nombre"].ToString();
                    ec.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(ec);
                }
            }
            return lista;
        }

        public static EstadoCargo BuscarPorId(byte pId)
        {
            EstadoCargo ec = null;
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoCargo WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    ec = new EstadoCargo();
                    ec.Id = Convert.ToByte(reader["Id"]);
                    ec.Nombre = reader["Nombre"].ToString();
                    ec.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return ec;
        }

        public static List<EstadoCargo> ObtenerHabilitados()
        {
            List<EstadoCargo> lista = new List<EstadoCargo>();
            string consulta = "SELECT Id, Nombre, IdEstado FROM EstadoCargo WHERE IdEstado = 1"; 
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EstadoCargo ec = new EstadoCargo();
                    ec.Id = Convert.ToByte(reader["Id"]);
                    ec.Nombre = reader["Nombre"].ToString();
                    ec.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(ec);
                }
            }
            return lista;
        }
    }

    public class EstadoCargo
    {
        public object Nombre { get; internal set; }
        public object IdEstado { get; internal set; }
        public object Id { get; internal set; }
    }
}