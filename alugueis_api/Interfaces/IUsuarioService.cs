using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.Repositories;

namespace Alugueis_API.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuarioAsync(UsuarioDTO dto);
        Task RemoveUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(UsuarioDTO dto);
        Task<GetAuthDTO> Autenticar(AuthDTO dto);
        Task<bool> Existe(int codUsuario = 0);
    }
}
