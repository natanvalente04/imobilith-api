using alugueis_api.Interfaces;
using alugueis_api.Interfaces.Security;
using alugueis_api.Models;
using alugueis_api.Models.DTOs;
using alugueis_api.Models.DTOs.Request;
using alugueis_api.Models.DTOs.Response;
using alugueis_api.Repositories;
using alugueis_api.Utilities;
using Microsoft.AspNetCore.Identity;

namespace alugueis_api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _UsuarioRepository;
        private readonly IGerenciadorToken _GerenciadorToken;
        public UsuarioService(UsuarioRepository usuarioRepository, IGerenciadorToken gerenciadorToken)
        {
            _UsuarioRepository = usuarioRepository;
            _GerenciadorToken = gerenciadorToken;
        }

        public async Task AddUsuarioAsync(UsuarioDTO dto)
        {
            Usuario usuario = CreateUsuario(dto);
            _UsuarioRepository.Add(usuario);
            await _UsuarioRepository.SaveChangesAsync();
        }

        public async Task<GetAuthDTO> Autenticar(AuthDTO dto)
        {
            Usuario usuario = await _UsuarioRepository.GetByLoginAsync(dto.login);
            bool autenticou = PasswordHelper.VerificarSenha(dto.password, usuario.SenhaHash, usuario.SenhaSalt);
            if (!autenticou)
            {
                return null;
            }
            return await _GerenciadorToken.GenerateTokenAsync(usuario);
        }

        public Usuario CreateUsuario(UsuarioDTO dto)
        {
            PasswordHelper.CriarSenhaHash(dto.Senha, out byte[] Hash, out byte[] salt);
            Usuario usuario = new Usuario
            {
                CodUsuario = dto.CodUsuario,
                CodPessoa = dto.CodPessoa,
                Ativo = dto.Ativo,
                SenhaHash = Hash,
                SenhaSalt = salt,
                Role = dto.Role,
            };
            return usuario;
        }

        public async Task RemoveUsuarioAsync(Usuario usuario)
        {
            _UsuarioRepository.Remove(usuario);
            await _UsuarioRepository.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(UsuarioDTO dto)
        {
            Usuario usuario = await _UsuarioRepository.GetAsync(dto.CodUsuario);
            Usuario usuarioAtualizado = CreateUsuario(dto);
            if (usuario == null) return;
            if (usuario == null) return;
            _UsuarioRepository.Update(usuario, usuarioAtualizado);
            await _UsuarioRepository.SaveChangesAsync();
        }
    }
}
