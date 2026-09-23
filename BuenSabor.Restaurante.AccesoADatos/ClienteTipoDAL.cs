using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocios;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class ClienteTipoDAL
    {
        public static string ConnectionString { get; private set; }

        public static int Guardar(ClienteTipo pClienteTipo)
        {
            { 
                string consulta = "INSERT INTO ClienteTipo (Nombre,Descripcion,Estado,IdEstado) VALUES (@Nombre,@Descripcion,@Estado,@IdEstado)";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Nombre", pClienteTipo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", pClienteTipo.Descripcion);
                comando.Parameters.AddWithValue("@Estado", pClienteTipo.Estado);
                comando.Parameters.AddWithValue("@IdEstado", pClienteTipo.IdEstado);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Modificar(ClienteTipo pClienteTipo)
        {
            {
                string consulta = "UPDATE ClienteTipo SET Nombre = @Nombre, @Descripcion, @Estado  @IdEstado WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText= consulta;
                comando.Parameters.AddWithValue("@Nombre", pClienteTipo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", pClienteTipo.Descripcion);
                comando.Parameters.AddWithValue("@Estado", pClienteTipo.Estado);
                comando.Parameters.AddWithValue("@IdEstado", pClienteTipo.IdEstado);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Eliminar(ClienteTipo pClienteTipo)
        {
            {
                string consulta = "DELETE FROM ClienteTipo WHERE Id=@Id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Id", pClienteTipo.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<ClienteTipo> ObtenerTodos()
        {
         string consulta = "SELEC TOP 500 Id, Nombre FROM ClienteTipo";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<ClienteTipo> listaclienteTipo = new List<ClienteTipo>();
            while (reader.Read()) ;
            {
             ClienteTipo clienteTipo = new ClienteTipo();
                clienteTipo.Id = reader.GetByte(0);
                clienteTipo.Nombre = reader.GetString(1);
                listaclienteTipo.Add(clienteTipo);
            }
            return listaclienteTipo;
        }

        public static ClienteTipo BuscarPorId(byte pId)
        {
            string consulta = "SELECT Id, Nombre FROM ClienteTipo  WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            ClienteTipo clienteTipo = new ClienteTipo();
            while (reader.Read())
            {
                clienteTipo.Id = reader.GetByte(0);
                clienteTipo.Nombre = reader.GetString(1);
            }
            return clienteTipo;

        }

        public static List<ClienteTipo> ObtenerHabilitados()
        {
         string consulta = "SELECT Id, Nombre FROM ClienteTipo  WHERE Habilitado = 1 ORDER BY Nombre";
         SqlCommand comando =  ComunDB.ObtenerComando();
         comando.CommandText = consulta;
         SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
         List<ClienteTipo>listaClienteTipos = new List<ClienteTipo> ();
            while (reader.Read()) 
            {
                    ClienteTipo clienteTipo = new ClienteTipo();
                    clienteTipo.Id = reader.GetByte(0);
                    clienteTipo.Nombre = reader.GetString(1);

                listaClienteTipos .Add(clienteTipo);
            }

            return listaClienteTipos;
        }
    }
}