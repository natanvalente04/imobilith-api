using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuarioAsync(AddUsuarioDTO dto);
        Task<List<GetUsuarioDTO>> GetUsuarios();
        Task<ActionResult> RemoveUsuarioByIdAsync(int codUsuario);
        Task RemoveUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(AddUsuarioDTO dto);
        Task<GetAuthDTO> Autenticar(AuthDTO dto);
        Task<bool> Existe(int codUsuario = 0);
        Task<GetUsuarioDTO> GetUsuarioById(int? codUsuario);
    }
}
