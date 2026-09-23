
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BuenSabor.Restaurante.EntidadesDeNegocios;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class TurnoDAL
    {
        public static int Guardar(Turno pTurno)
        {
            string consulta = "INSERT INTO Turno(Nombre, HoraEntrada, HoraSalida, IdEstado) VALUES(@Nombre, @HoraEntrada, @HoraSalida, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pTurno.Nombre);
            comando.Parameters.AddWithValue("@HoraEntrada", pTurno.HoraEntrada);
            comando.Parameters.AddWithValue("@HoraSalida", pTurno.HoraSalida);
            comando.Parameters.AddWithValue("@IdEstado", pTurno.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Turno pTurno)
        {
            string consulta = "UPDATE Turno SET Nombre=@Nombre, HoraEntrada=@HoraEntrada, HoraSalida=@HoraSalida, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pTurno.Id);
            comando.Parameters.AddWithValue("@Nombre", pTurno.Nombre);
            comando.Parameters.AddWithValue("@HoraEntrada", pTurno.HoraEntrada);
            comando.Parameters.AddWithValue("@HoraSalida", pTurno.HoraSalida);
            comando.Parameters.AddWithValue("@IdEstado", pTurno.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Turno pTurno)
        {
            string consulta = "DELETE FROM Turno WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pTurno.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<Turno> ObtenerTodos()
        {
            List<Turno> lista = new List<Turno>();
            string consulta = "SELECT Id, Nombre, HoraEntrada, HoraSalida, IdEstado FROM Turno";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = Convert.ToByte(reader["Id"]);
                    turno.Nombre = reader["Nombre"].ToString();
                    turno.HoraEntrada = (TimeSpan)reader["HoraEntrada"];
                    turno.HoraSalida = (TimeSpan)reader["HoraSalida"];
                    turno.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(turno);
                }
            }
            return lista;
        }

        public static Turno BuscarPorId(byte pId)
        {
            Turno turno = null;
            string consulta = "SELECT Id, Nombre, HoraEntrada, HoraSalida, IdEstado FROM Turno WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    turno = new Turno();
                    turno.Id = Convert.ToByte(reader["Id"]);
                    turno.Nombre = reader["Nombre"].ToString();
                    turno.HoraEntrada = (TimeSpan)reader["HoraEntrada"];
                    turno.HoraSalida = (TimeSpan)reader["HoraSalida"];
                    turno.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return turno;
        }

        public static List<Turno> ObtenerHabilitados()
        {
            List<Turno> lista = new List<Turno>();
            string consulta = "SELECT Id, Nombre, HoraEntrada, HoraSalida, IdEstado FROM Turno WHERE IdEstado = 1"; // 1 = Habilitado
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = Convert.ToByte(reader["Id"]);
                    turno.Nombre = reader["Nombre"].ToString();
                    turno.HoraEntrada = (TimeSpan)reader["HoraEntrada"];
                    turno.HoraSalida = (TimeSpan)reader["HoraSalida"];
                    turno.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(turno);
                }
            }
            return lista;
        }
    }
}