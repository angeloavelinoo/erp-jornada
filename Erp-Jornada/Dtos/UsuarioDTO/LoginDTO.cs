using System.ComponentModel.DataAnnotations;

namespace Erp_Jornada.Dtos.UsuarioDTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é invalido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha invalida")]
        public string? Senha { get; set; }
    }
}
