
using System.ComponentModel.DataAnnotations;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Usuarios
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre de usuario no debe superar los 20 caracteres entre mayusculas, minusculas y alfanumericos")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
