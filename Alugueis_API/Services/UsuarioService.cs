using Alugueis_API.Interfaces;
using Alugueis_API.Interfaces.Security;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.Repositories;
using Alugueis_API.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Alugueis_API.Services
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

        public async Task<Usuario> AddUsuarioAsync(AddUsuarioDTO dto)
        {
            Usuario usuario = CreateUsuario(dto);
            _UsuarioRepository.Add(usuario);
            await _UsuarioRepository.SaveChangesAsync();
            return usuario;
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

        public async Task RemoveUsuarioAsync(Usuario usuario)
        {
            _UsuarioRepository.Remove(usuario);
            await _UsuarioRepository.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(AddUsuarioDTO dto)
        {
            Usuario usuario = await _UsuarioRepository.GetAsync(dto.CodUsuario);
            Usuario usuarioAtualizado = CreateUsuario(dto);
            if (usuario == null) return;
            if (usuario == null) return;
            _UsuarioRepository.Update(usuario, usuarioAtualizado);
            await _UsuarioRepository.SaveChangesAsync();
        }

        public Usuario CreateUsuario(AddUsuarioDTO dto)
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

        public async Task<bool> Existe(int codUsuario)
        {
            return await _UsuarioRepository.Exists();
        }
    }
}
