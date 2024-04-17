using Erp_Jornada.Dtos.UsuarioDTO;
using Erp_Jornada.Model;
using Erp_Jornada.Repository;
using Erp_Jornada.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Erp_Jornada.Services
{
    public class UsuarioService(UsuarioRepository usuarioRepository)
    {
        private readonly UsuarioRepository _usuarioRepository = usuarioRepository;
        public async Task<ResultModel<dynamic>> Add(RegisterDto usuarioDTO)
        {
            var usuario = new Usuario(
                new(usuarioDTO.Nome), (usuarioDTO.Email),
                 BCrypt.Net.BCrypt.HashPassword(usuarioDTO.Senha), (usuarioDTO.Role));

            if (await _usuarioRepository.AlredyExist(usuarioDTO.Email))
                return new(HttpStatusCode.Conflict, "Email já cadastrado");

            await _usuarioRepository.Create(usuario);

            return new();

        }

        public async Task<ResultModel<dynamic>> Login(LoginDTO usuarioDTO)
        {
            Usuario usuario = await _usuarioRepository.GetByEmail(usuarioDTO.Email);

            if (usuario?.Senha != null && BCrypt.Net.BCrypt.Verify(usuarioDTO.Senha, usuario.Senha))
                return new ResultModel<dynamic>(new
                {
                    token = TokenService.GenerateToken(usuario)
                });

            return new(HttpStatusCode.BadRequest, "Email ou senha inválida");
        }
    }
}
