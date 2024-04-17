using System.ComponentModel.DataAnnotations;

namespace Erp_Jornada.Dtos.UsuarioDTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é invalido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }
        public string? Role { get; set; }


    }
}
