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

        public async Task AddUsuarioAsync(AddUsuarioAdminDTO dto)
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
            _UsuarioRepository.Add(usuario);
            await _UsuarioRepository.SaveChangesAsync();
        }

        public Task RemoveUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsuarioAsync()
        {
            throw new NotImplementedException();
        }
    }
}
