
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EmpleadoDAL
    {
        public static int Guardar(Empleado pEmpleado)
        {
            string consulta = "INSERT INTO Empleado(Nombres, Apellidos, Dui, Telefono, IdCargo, IdEstado) VALUES(@Nombres, @Apellidos, @Dui, @Telefono, @IdCargo, @IdEstado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombres", pEmpleado.Nombre);
            comando.Parameters.AddWithValue("@Apellidos", pEmpleado.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pEmpleado.Telefono);
            comando.Parameters.AddWithValue("@IdCargo", pEmpleado.IdCargo);
            comando.Parameters.AddWithValue("@IdEstado", pEmpleado.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Empleado pEmpleado)
        {
            string consulta = "UPDATE Empleado SET Nombres=@Nombres, Apellidos=@Apellidos, Dui=@Dui, Telefono=@Telefono, IdCargo=@IdCargo, IdEstado=@IdEstado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEmpleado.Id);
            comando.Parameters.AddWithValue("@Nombres", pEmpleado.Nombre);
            comando.Parameters.AddWithValue("@Apellidos", pEmpleado.Apellido);
            comando.Parameters.AddWithValue("@Telefono", pEmpleado.Telefono);
            comando.Parameters.AddWithValue("@IdCargo", pEmpleado.IdCargo);
            comando.Parameters.AddWithValue("@IdEstado", pEmpleado.IdEstado);
            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Empleado pEmpleado)
        {
            string consulta = "DELETE FROM Empleado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEmpleado.Id);
            return ComunDB.EjecutarComando(comando);
        }

        public static List<Empleado> ObtenerTodos()
        {
            List<Empleado> lista = new List<Empleado>();
            string consulta = "SELECT Id, Nombres, Apellidos, Dui, Telefono, IdCargo, IdEstado FROM Empleado";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empleado emp = new Empleado();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Nombre = reader["Nombres"].ToString();
                    emp.Apellido = reader["Apellidos"].ToString();
                    emp.Telefono = reader["Telefono"].ToString();
                    emp.IdCargo = Convert.ToByte(reader["IdCargo"]);
                    emp.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(emp);
                }
            }
            return lista;
        }

        public static Empleado BuscarPorId(int pId)
        {
            Empleado emp = null;
            string consulta = "SELECT Id, Nombres, Apellidos, Dui, Telefono, IdCargo, IdEstado FROM Empleado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Empleado();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Nombre = reader["Nombres"].ToString();
                    emp.Apellido = reader["Apellidos"].ToString();
                    emp.Telefono = reader["Telefono"].ToString();
                    emp.IdCargo = Convert.ToByte(reader["IdCargo"]);
                    emp.IdEstado = Convert.ToByte(reader["IdEstado"]);
                }
            }
            return emp;
        }

        public static List<Empleado> ObtenerHabilitados()
        {
            List<Empleado> lista = new List<Empleado>();
            string consulta = "SELECT Id, Nombres, Apellidos, Dui, Telefono, IdCargo, IdEstado FROM Empleado WHERE IdEstado = 1"; 
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            using (comando.Connection)
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empleado emp = new Empleado();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Nombre = reader["Nombres"].ToString();
                    emp.Apellido = reader["Apellidos"].ToString();
                    emp.Telefono = reader["Telefono"].ToString();
                    emp.IdCargo = Convert.ToByte(reader["IdCargo"]);
                    emp.IdEstado = Convert.ToByte(reader["IdEstado"]);
                    lista.Add(emp);
                }
            }
            return lista;
        }
    }
}