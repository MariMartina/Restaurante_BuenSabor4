using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class DistritoDAL
    {
        public static string ConnectionString { get; private set; }

        public static int Guardar(Distrito pDistrito)
        {
            {
                string consulta = "INSERT INTO Distrito (Nombre, IdDepartamento, Habilitado) VALUES (@Nombre, @IdDepartamento, @Habilitado)";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Nombre", pDistrito.Nombre);
                comando.Parameters.AddWithValue("@IdDepartamento", pDistrito.IdDepartamento);
                comando.Parameters.AddWithValue("@Habilitado", pDistrito.Habilitado);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Modificar(Distrito pDistrito)
        {
            {
                string consulta = "UPDATE Distrito SET Nombre=@Nombre, IdDepartamento=@IdDepartamento, Habilitado=@Habilitado WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText= consulta;
                comando.Parameters.AddWithValue("@Nombre", pDistrito.Nombre);
                comando.Parameters.AddWithValue("@IdDepartamento", pDistrito.IdDepartamento);
                comando.Parameters.AddWithValue("@Habilitado", pDistrito.Habilitado);
                comando.Parameters.AddWithValue("@Id", pDistrito.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Eliminar(Distrito pDistrito)
        {
            {
                string consulta = "DELETE FROM Distrito WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Id", pDistrito.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<Distrito> ObtenerTodos()
        {
            string consulta = "SELECT TOP 500 e.Id, e.Nombre FROM Distrito e";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Distrito> listadistrito = new List<Distrito>();
            while (reader.Read())
            { 
                Distrito distrito = new Distrito();
                distrito.Id = reader.GetByte(0);
                distrito.Nombre = reader.GetString(1);
                listadistrito.Add(distrito);
            }
            return listadistrito;
        }

        public static Distrito BuscarPorId(byte pId) 
        {
            string consulta = "SELECT e.Id, e.Nombre FROM Distrito WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText= consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Distrito distrito = new Distrito();
            while (reader.Read())
                {
                distrito.Id = reader.GetByte(0);
                distrito.Nombre = reader.GetString(1);
                }
            return distrito;
        }

        public static List<Distrito> ObtenerHabilitados()
        {
            string consulta = "SELECT Id, Nombre FROM Distrito  WHERE Habilitado = 1 ORDER BY Nombre";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Distrito>listadistrito = new List<Distrito>();
            while (reader.Read())
            {
                Distrito distrito = new Distrito();
                distrito.Id = reader.GetByte(0);
                distrito.Nombre = reader.GetString(1);

                listadistrito.Add( distrito );
            }
            return listadistrito;
        }
    }
}