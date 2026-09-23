using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EmpleadoTurnoDAL
    {
        public static int Guardar(EmpleadoTurno pEmpleadoTurno)
        {
            string consulta = "INSERT INTO EmpleadoTurno(IdEmpleado, IdTurno, Fecha, IdEstado) VALUES(@IdEmpleado, @IdTurno, @Fecha, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEmpleado", pEmpleadoTurno.IdEmpleado);
            comando.Parameters.AddWithValue("@IdTurno", pEmpleadoTurno.IdTurno);
            comando.Parameters.AddWithValue("@Fecha", pEmpleadoTurno.Fecha);
            comando.Parameters.AddWithValue("@IdEstado", pEmpleadoTurno.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(EmpleadoTurno pEmpleadoTurno)
        {
            string consulta = "UPDATE EmpleadoTurno SET IdEmpleado=@IdEmpleado, IdTurno=@IdTurno, Fecha=@Fecha, IdEstado=@IdEstado WHERE IdEmpleado=@IdEmpleado AND IdTurno=@IdTurno AND Fecha=@FechaAntigua";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEmpleado", pEmpleadoTurno.IdEmpleado);
            comando.Parameters.AddWithValue("@IdTurno", pEmpleadoTurno.IdTurno);
            comando.Parameters.AddWithValue("@Fecha", pEmpleadoTurno.Fecha);
            comando.Parameters.AddWithValue("@IdEstado", pEmpleadoTurno.IdEstado);
            comando.Parameters.AddWithValue("@FechaAntigua", pEmpleadoTurno.Fecha); // Si la PK es compuesta
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(EmpleadoTurno pEmpleadoTurno)
        {
            string consulta = "DELETE FROM EmpleadoTurno WHERE IdEmpleado=@IdEmpleado AND IdTurno=@IdTurno AND Fecha=@Fecha";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEmpleado", pEmpleadoTurno.IdEmpleado);
            comando.Parameters.AddWithValue("@IdTurno", pEmpleadoTurno.IdTurno);
            comando.Parameters.AddWithValue("@Fecha", pEmpleadoTurno.Fecha);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<EmpleadoTurno> ObtenerTodos()
        {
            List<EmpleadoTurno> lista = new List<EmpleadoTurno>();
            string consulta = "SELECT IdEmpleado, IdTurno, Fecha, IdEstado FROM EmpleadoTurno";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EmpleadoTurno et = new EmpleadoTurno();
                    et.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    et.IdTurno = Convert.ToByte(reader["IdTurno"]);
                    et.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    et.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(et);
                }
            }
            return lista;
        }

        public static EmpleadoTurno BuscarPorId(int pIdEmpleado, byte pIdTurno, DateTime pFecha)
        {
            EmpleadoTurno et = null;
            string consulta = "SELECT IdEmpleado, IdTurno, Fecha, IdEstado FROM EmpleadoTurno WHERE IdEmpleado=@IdEmpleado AND IdTurno=@IdTurno AND Fecha=@Fecha";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdEmpleado", pIdEmpleado);
            comando.Parameters.AddWithValue("@IdTurno", pIdTurno);
            comando.Parameters.AddWithValue("@Fecha", pFecha);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    et = new EmpleadoTurno();
                    et.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    et.IdTurno = Convert.ToByte(reader["IdTurno"]);
                    et.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    et.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return et;
        }

        public static List<EmpleadoTurno> ObtenerHabilitados()
        {
            List<EmpleadoTurno> lista = new List<EmpleadoTurno>();
            string consulta = "SELECT IdEmpleado, IdTurno, Fecha, IdEstado FROM EmpleadoTurno WHERE IdEstado = 1"; // 1 = Habilitado
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EmpleadoTurno et = new EmpleadoTurno();
                    et.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    et.IdTurno = Convert.ToByte(reader["IdTurno"]);
                    et.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    et.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(et);
                }
            }
            return lista;
        }
    }
}