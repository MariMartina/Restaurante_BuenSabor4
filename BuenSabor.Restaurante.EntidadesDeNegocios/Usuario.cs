using System.ComponentModel.DataAnnotations;

namespace BuenSabor.Restaurante.EntidadesDeNegocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Escriba su correo.")]
        [EmailAddress(ErrorMessage = "Escriba un correo válido.")]
        [StringLength(150)]
        public string Correo { get; set; } = "";

        [Required(ErrorMessage = "Escriba su contraseña.")]
        [DataType(DataType.Password)]
        public string Clave { get; set; } = "";

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = "Vendedor";
        public bool Estado { get; set; }
    }
}