using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocio;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class EstadoPagoDAL
    {
        public static string ConnectionString { get; private set; }

        public static int Guardar(EstadoPago pEstadoPago)
        {
            {
                string consulta = "INSERT INTO EstadoPago (Descripcion, Habilitado) VALUES (@Descripcion, @Habilitado)";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Descripcion", pEstadoPago.Descripcion);
                comando.Parameters.AddWithValue("@Habilitado", pEstadoPago.Habilitado);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Modificar(EstadoPago pEstadoPago)
        {
            {
                string consulta = "UPDATE EstadoPago SET Descripcion=@Descripcion, Habilitado=@Habilitado WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.Parameters.AddWithValue("@Desc", pEstadoPago.Descripcion);
                comando.Parameters.AddWithValue("@Hab", pEstadoPago.Habilitado);
                comando.Parameters.AddWithValue("@Id", pEstadoPago.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Eliminar(EstadoPago pEstadoPago)
        {
            {
                string consulta = "DELETE FROM EstadoPago WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.Parameters.AddWithValue("@Id", pEstadoPago.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<EstadoPago> ObtenerTodos()
        {
            string consulta = "SELECT TOP 500 Id, Habilitados FROM EstadoPago";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            List<EstadoPago> listaestadoPago = new List<EstadoPago>();
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            while (reader.Read()) ;
            {
                EstadoPago estadoPago = new EstadoPago();
                estadoPago.Id = reader.GetByte(0);
                estadoPago.Nombre = reader.GetString(1);
                listaestadoPago.Add(estadoPago);

            }
            return listaestadoPago;
        }


        public static EstadoPago BuscarPorId(byte pId)
        {
            string consulta = "SELECT Id, Habilitados FROM EstadoPago WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            EstadoPago estadoPago = new EstadoPago();
            while (reader.Read())
            {
                estadoPago.Id = reader.GetByte(0);
                estadoPago.Nombre = reader.GetString(1);
            }
            return estadoPago;
        }
        

        public static List<EstadoPago> ObtenerHabilitados()
        {
           string consulta = "SELECT Id, Habilitados FROM EstadoPago WHERE Habilitado = 1";
           SqlCommand comando = ComunDB.ObtenerComando();
           comando.CommandText= consulta;
           SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
           List<EstadoPago>listaestadoPago = new List<EstadoPago>();
            while (reader.Read())
            {
                EstadoPago estadoPago = new EstadoPago();
                estadoPago.Id = reader.GetByte(0);
                estadoPago.Nombre = reader.GetString(1);

                listaestadoPago.Add(estadoPago);
            }
            return listaestadoPago;
        }
    }
}
