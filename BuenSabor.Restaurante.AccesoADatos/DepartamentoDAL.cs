using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class DepartamentoDAL
    {
        public static string ConnectionString { get; private set; }

        public static int  Guardar(Departamento pDepartamento)
        {
            {
                string consulta = "INSERT INTO Departamento (Nombre, Codigo, Habilitado) VALUES (@Nombre, @Codigo, @Habilitado)";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Nombre", pDepartamento.Nombre);
                comando.Parameters.AddWithValue("@Codigo", pDepartamento.Codigo);
                comando.Parameters.AddWithValue("@Habilitado", pDepartamento.Habilitado);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Modificar(Departamento pDepartamento)
        {
            {
                string consulta = "UPDATE Departamento SET Nombre = @Nombre, Codigo = @Codigo, Habilitado = @Habilitado WHERE Id = @Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.Parameters.AddWithValue("@Nombre", pDepartamento.Nombre);
                comando.Parameters.AddWithValue("@Codigo", pDepartamento.Codigo);
                comando.Parameters.AddWithValue("@Habilitado", pDepartamento.Habilitado);
                comando.Parameters.AddWithValue("@Id", pDepartamento.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Eliminar(Departamento pDerpatamento)
        {
            {
                string consulta = "DELETE FROM Departamento WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Id", pDerpatamento.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<Departamento> ObtenerTodos()
        {
            string consulta = "SELEC TOP 500 Id, Nombre From Estado";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Departamento> listadepartamento = new List<Departamento>();
            while (reader.Read()) ;
            {
                Departamento departamento = new Departamento();
                departamento.Id = reader.GetByte(0);
                departamento.Nombre = reader.GetString(1);
                listadepartamento.Add(departamento);
            }
            return listadepartamento;
        }

        public static Departamento BuscarPorId(byte pId)
        { 
            string consulta = "SELECT Id, Nombre FROM Departamento WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText= consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Departamento departamento = new Departamento();
            while (reader.Read())
            {
               departamento.Id = reader.GetByte(0);
               departamento.Nombre= reader.GetString(1);
            }
            return departamento;
        }

        public static List<Departamento> ObtenerHabilitados()
        {
            string consulta = "SELECT Id, Nombre FROM Departamento WHERE Habilitado = 1 ORDER BY Nombre";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Departamento>listaDepartamento = new List<Departamento>();
            while (reader.Read())
            {
                Departamento departamento = new Departamento();
                departamento.Id = reader.GetByte(0);
                departamento.Nombre = reader.GetString(1);

                listaDepartamento.Add(departamento);
            }
            return listaDepartamento;
        }
    }
}
