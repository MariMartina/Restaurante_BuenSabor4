using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class ComunDB
    {
        const string CadenaConexion = @"Server=localhost;Database=BDDesarrollo;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;

        }
        public static SqlCommand ObtenerComando()
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = ObtenerConexion();
            return comando;

        }
        public static int EjecutarComando(SqlCommand pComando)
        {
            int resultado = pComando.ExecuteNonQuery();
            pComando.Connection.Close();
            return resultado;

        }
        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}

    
