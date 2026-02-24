using Alugueis_API.Interfaces;
using Alugueis_API.Interfaces.Security;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.Repositories;
using Alugueis_API.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            Usuario usuario = await _UsuarioRepository.GetByLoginAsync(dto.Login);
            bool autenticou = PasswordHelper.VerificarSenha(dto.Senha, usuario.SenhaHash, usuario.SenhaSalt);
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
            if (usuarioAtualizado.SenhaSalt == null && usuarioAtualizado.SenhaHash == null)
            {
                usuarioAtualizado.SenhaSalt = usuario.SenhaSalt;
                usuarioAtualizado.SenhaHash = usuario.SenhaHash;
            }
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

        public async Task<List<GetUsuarioDTO>> GetUsuarios()
        {
            List<Usuario> usuarios = await _UsuarioRepository.GetAllAsync();
            return GetUsuariosDTO(usuarios);
        }
        private List<GetUsuarioDTO> GetUsuariosDTO(List<Usuario> usuarios)
        {
            List<GetUsuarioDTO> usuariosDTO = new List<GetUsuarioDTO>();
            foreach (Usuario usuario in usuarios)
            {
                usuariosDTO.Add(GetUsuarioDTO(usuario));
            }
            return usuariosDTO;
        }

        private GetUsuarioDTO GetUsuarioDTO(Usuario usuario)
        {
            return new GetUsuarioDTO(
                    usuario.CodUsuario,
                    usuario.CodPessoa,
                    usuario.Role,
                    usuario.Ativo
                );
        }

        public async Task<ActionResult> RemoveUsuarioByIdAsync(int codUsuario)
        {
            Usuario usuario = await _UsuarioRepository.GetAsync(codUsuario);
            if (usuario == null) return new OkObjectResult(null);
            await RemoveUsuarioAsync(usuario);
            return new OkObjectResult(null);
        }

        public async Task<GetUsuarioDTO> GetUsuarioById(int? codUsuario)
        {
            Usuario usuario = await _UsuarioRepository.GetAsync(codUsuario);
            return GetUsuarioDTO(usuario);
        }

        public async Task<bool> ExisteByPessoaId(int codPessoa)
        {
            Usuario usuario = await _UsuarioRepository.GetUsuarioByPessoaIdAsync(codPessoa);
            if (usuario == null) return false;
            if (usuario.CodPessoa == codPessoa)
            {
                return true;
            }
            return false;
        }
    }
}
