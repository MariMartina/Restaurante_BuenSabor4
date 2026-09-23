using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocio;
using Microsoft.Data.SqlClient;

namespace BuenSabor.Restaurante.AccesoADatos
{
    public class MenuDAL
    {
        private static Menu menu;

        public static string ConnectionString { get; private set; }

        public static int Guardar(Menu pMenu)
        {
            string consulta = "INSERT INTO Menu(Nombre,Url,Icono,IdMenuPadre,Orden,Habilitado)VALUES(@Nombre,@Url,@Icono,@IdMenuPadre,@Orden,@Habilitado)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pMenu.Nombre);
            comando.Parameters.AddWithValue("@u", pMenu.Url);
            comando.Parameters.AddWithValue("@i", pMenu.Icono);
            comando.Parameters.AddWithValue("@p", pMenu.IdMenuPadre);
            comando.Parameters.AddWithValue("@o", pMenu.Orden);
            comando.Parameters.AddWithValue("@h", pMenu.Habilitado);
            return ComunDB.EjecutarComando(comando);
            
        }

        public static int Modificar(Menu pMenu)
        {
            {
                string consulta = "UPDATE Menu SET Nombre=@Nombre,Url=@Url,Icono=@Icono,IdMenuPadre=@IdMenuPadre,Orden=@Orden,Habilitado=@Habilitado WHERE Id=@id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@Nombre", pMenu.Nombre);
                comando.Parameters.AddWithValue("@Url", pMenu.Url);
                comando.Parameters.AddWithValue("@Icono", pMenu.Icono);
                comando.Parameters.AddWithValue("@IdMenuPadre", pMenu.IdMenuPadre);
                comando.Parameters.AddWithValue("@Orden", pMenu.Orden);
                comando.Parameters.AddWithValue("@Habilitado", pMenu.Habilitado);
                comando.Parameters.AddWithValue("@Id", pMenu.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static int Eliminar(Menu pMenu)
        {
            {
                string consulta = "DELETE FROM Menu WHERE Id=@id";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@id", pMenu.Id);
                return ComunDB.EjecutarComando(comando);
            }
        }

        public static List<Menu> ObtenerTodos()
        { 
            {
                string consulta = "SELECT TOP 500 Id Nombre FROM Menu";
                SqlCommand comando = ComunDB.ObtenerComando();
                comando.CommandText = consulta;
                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                List<Menu> listamenu = new List<Menu>();
                while (reader.Read()) ;
                {
                  Menu menu = new Menu();
                    menu.Id = reader.GetByte(0);
                    menu.Nombre = reader.GetString(1);
                    listamenu.Add(menu);
                }
                return listamenu;
            }
            
        }

        public static Menu BuscarPorId(byte pId) 
        {
            string consulta = "SELECT Id, Nombre FROM Menu WHERE Id=@id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Menu menu = new Menu();
                {
                menu.Id = reader.GetByte(0);
                menu.Nombre = reader.GetString(1);
                }
            return menu;
        }

        public static List<Menu> ObtenerHabilitados()
        {
            string consulta = "SELECT Id, Nombre FROM Menu WHERE Habilitado=1 ORDER BY Nombre";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Menu> listamenu = new List<Menu>();
            while (reader.Read())
            {
                Menu menu = new Menu();
                menu.Id = reader.GetByte(0);
                menu.Nombre = reader.GetString(1);

                listamenu.Add(menu);
            }  
              return listamenu;
        }
        
    }
}
