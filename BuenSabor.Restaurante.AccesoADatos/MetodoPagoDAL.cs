
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BuenSaborRestaurante.EntidadesDeNegocio;

namespace BuenSaborRestaurante.AccesoDatos
{
    public class MetodoPagoDAL
    {
        public bool Guardar(MetodoPago pMetodoPago)
        {
            string consulta = "INSERT INTO MetodoPago (Nombre, Descripcion, Habilitado) VALUES (@Nombre, @Descripcion, @Habilitado)";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pMetodoPago.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pMetodoPago.Descripcion ?? (object)DBNull.Value);
            comando.Parameters.AddWithValue("@Habilitado", pMetodoPago.Habilitado);
            return ConexionDB.EjecutarComando(comando) > 0;
        }

        public bool Modificar(MetodoPago pMetodoPago)
        {
            string consulta = "UPDATE MetodoPago SET Nombre=@Nombre, Descripcion=@Descripcion, Habilitado=@Habilitado WHERE Id=@Id";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pMetodoPago.Id);
            comando.Parameters.AddWithValue("@Nombre", pMetodoPago.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", pMetodoPago.Descripcion ?? (object)DBNull.Value);
            comando.Parameters.AddWithValue("@Habilitado", pMetodoPago.Habilitado);
            return ConexionDB.EjecutarComando(comando) > 0;
        }

        public bool Eliminar(int id)
        {
            string consulta = "DELETE FROM MetodoPago WHERE Id=@Id";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", id);
            return ConexionDB.EjecutarComando(comando) > 0;
        }

        public List<MetodoPago> ObtenerTodos()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            string consulta = "SELECT Id, Nombre, Descripcion, Habilitado FROM MetodoPago ORDER BY Nombre";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader lector = ConexionDB.EjecutarConsulta(comando);

            while (lector.Read())
            {
                MetodoPago mp = new MetodoPago();
                mp.Id = Convert.ToInt32(lector["Id"]);
                mp.Nombre = lector["Nombre"].ToString();
                mp.Descripcion = lector["Descripcion"] == DBNull.Value ? "" : lector["Descripcion"].ToString();
                mp.Habilitado = Convert.ToBoolean(lector["Habilitado"]);
                lista.Add(mp);
            }
            lector.Close();
            return lista;
        }

        public MetodoPago BuscarPorId(int id)
        {
            MetodoPago mp = null;
            string consulta = "SELECT Id, Nombre, Descripcion, Habilitado FROM MetodoPago WHERE Id=@Id";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", id);
            SqlDataReader lector = ConexionDB.EjecutarConsulta(comando);

            if (lector.Read())
            {
                mp = new MetodoPago();
                mp.Id = Convert.ToInt32(lector["Id"]);
                mp.Nombre = lector["Nombre"].ToString();
                mp.Descripcion = lector["Descripcion"] == DBNull.Value ? "" : lector["Descripcion"].ToString();
                mp.Habilitado = Convert.ToBoolean(lector["Habilitado"]);
            }
            lector.Close();
            return mp;
        }

        public List<MetodoPago> ObtenerHabilitados()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            string consulta = "SELECT Id, Nombre, Descripcion, Habilitado FROM MetodoPago WHERE Habilitado=1 ORDER BY Nombre";
            SqlCommand comando = ConexionDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader lector = ConexionDB.EjecutarConsulta(comando);

            while (lector.Read())
            {
                MetodoPago mp = new MetodoPago();
                mp.Id = Convert.ToInt32(lector["Id"]);
                mp.Nombre = lector["Nombre"].ToString();
                mp.Descripcion = lector["Descripcion"] == DBNull.Value ? "" : lector["Descripcion"].ToString();
                mp.Habilitado = Convert.ToBoolean(lector["Habilitado"]);
                lista.Add(mp);
            }
            lector.Close();
            return lista;
        }
    }
}
