using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocio;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EstadoDAL
    {
        public static int Guardar(Estado pEstado)
        {
            string consulta = "INSERT INTO Estado(Nombre) VALUES(@Nombre)";
            SqlCommand Comando = ComunDB.ObtenerComando();
            Comando.CommandText = consulta;
            Comando.Parameters.AddWithValue("@Nombre", pEstado.Nombre);
            return ComunDB.EjecutarComando(Comando);
            
        }
        public static int Modificar(Estado pEstado)
        {
            string consulta = "UPDATE Estado SET Nombre=@Nombre WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pEstado.Nombre);
            comando.Parameters.AddWithValue("@Id", pEstado.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar (Estado pEstado) 
        {
            string consulta = "DELETE FROM Estado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstado.Id);
            return ComunDB.EjecutarComando(comando);  
        }  
        public static List<Estado> ObtenerTodos()
        {
            string consulta = "SELECT TOP 500 e.Id, e.Nombre FROM Estado e";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Estado> listaEstados = new List<Estado>();
            while (reader.Read())
            {
                Estado estado = new Estado();
                estado.Id = reader.GetByte(0);
                estado.Nombre = reader.GetString(1);
                listaEstados.Add(estado);
            }
            return listaEstados;
        }
        public static Estado BuscarPorId(Byte pId) 
        {
            string consulta = "SELECT e.Id, e.Nombre FROM Estado e WHERE e Id =@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Estado estado = new Estado();
            while (reader.Read()) 
            {
                estado.Id =reader.GetByte(0);
                estado.Nombre = reader.GetString(1);
            
            }
            return estado;
        }
        public static int ObtenerHabilitados(Estado pEstado)
        {
            int Cantidad = 0;
            SqlCommand Comando = ComunDB.ObtenerComando();
            Comando.CommandText = "SELECCCT COUNT(*) FROM Esatdo WHERE Habilitado = 1";
            using (Comando.Connection)
            {
                Cantidad = Convert.ToInt32(Comando.ExecuteScalar());
            }
            return Cantidad;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}







