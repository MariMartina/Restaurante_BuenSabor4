using System.ComponentModel.DataAnnotations;
using System.Text;
using BuenSabor.Restaurante.AccesoADatos;
using BuenSabor.Restaurante.EntidadesDeNegocio;

namespace BuenSabor.Restaurante.LogicaDeNegocios
{
    public class UsuarioBL
    {
        public static bool HayUsuarios()
        {
            return UsuarioDAL.HayUsuarios();
        }

        public static Usuario? IniciarSesion(Usuario pUsuario)
        {
            if (string.IsNullOrWhiteSpace(pUsuario.Correo) ||
                string.IsNullOrEmpty(pUsuario.Clave) ||
                pUsuario.Correo.Length > 150 ||
                Encoding.UTF8.GetByteCount(pUsuario.Clave) > 72)
            {
                return null;
            }
            string correo = pUsuario.Correo.Trim().ToLowerInvariant();
            Usuario? usuario = UsuarioDAL.BuscarPorCorreo(correo);
            if (usuario == null)
            {
                return null;
            }
            bool claveValida = BCrypt.Net.BCrypt.Verify(
                pUsuario.Clave, usuario.Clave);
            if (!claveValida)
            {
                return null;
            }
            return usuario;
        }

        private static Usuario? PrepararUsuario(Usuario pUsuario, bool pEsPrimero)
        {
            if (string.IsNullOrWhiteSpace(pUsuario.Nombre) ||
                string.IsNullOrWhiteSpace(pUsuario.Correo) ||
                string.IsNullOrEmpty(pUsuario.Clave))
            {
                return null;
            }
            
            var contexto = new ValidationContext(pUsuario);
            var resultados = new List<ValidationResult>();
            bool esValido = Validator.TryValidateObject(
                pUsuario, contexto, resultados, true);
            if (!esValido)
            {
                return null;
            }
            if (pUsuario.Correo.Length > 150 ||
                Encoding.UTF8.GetByteCount(pUsuario.Clave) > 72)
            {
                return null;
            }

            string correo = pUsuario.Correo.Trim().ToLowerInvariant();
            string hash = BCrypt.Net.BCrypt.HashPassword(pUsuario.Clave);

            
            Usuario usuarioListo = new Usuario
            {
                IdUsuario = pUsuario.IdUsuario,
                Nombre = pUsuario.Nombre.Trim(),
                Correo = correo,
                Clave = hash,
                IdRol = pUsuario.IdRol,
                NombreRol = pEsPrimero ? "Administrador" : pUsuario.NombreRol,
                Estado = true
            };
            return usuarioListo;
        }

        public static int Guardar(Usuario pUsuario)
        {
            Usuario? usuario = PrepararUsuario(pUsuario, false);
            if (usuario == null) return 0;
            return UsuarioDAL.Guardar(usuario);
        }

        public static int GuardarPrimerAdministrador(Usuario pUsuario)
        {
            Usuario? usuario = PrepararUsuario(pUsuario, true);
            if (usuario == null) return 0;
            return UsuarioDAL.Guardar(usuario);
        }
    }
}
