using alugueis_api.Interfaces;
using alugueis_api.Models;
using alugueis_api.Models.DTOs;
using alugueis_api.Repositories;
using alugueis_api.Utilities;
using Microsoft.AspNetCore.Identity;

namespace alugueis_api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _UsuarioRepository;
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        public async Task AddUsuarioAsync(UsuarioDTO dto)
        {
            Usuario usuario = CreateUsuario(dto);
            _UsuarioRepository.Add(usuario);
            await _UsuarioRepository.SaveChangesAsync();
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
