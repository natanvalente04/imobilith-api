using alugueis_api.Models;
using alugueis_api.Models.DTOs;
using alugueis_api.Models.DTOs.Request;
using alugueis_api.Models.DTOs.Response;
using alugueis_api.Repositories;

namespace alugueis_api.Interfaces
{
    public interface IUsuarioService
    {
        Task AddUsuarioAsync(UsuarioDTO dto);
        Task RemoveUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(UsuarioDTO dto);
        Task<GetAuthDTO> Autenticar(AuthDTO dto);
    }
}
