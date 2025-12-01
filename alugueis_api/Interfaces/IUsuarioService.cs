using alugueis_api.Models;
using alugueis_api.Models.DTOs;

namespace alugueis_api.Interfaces
{
    public interface IUsuarioService
    {
        Task AddUsuarioAsync(AddUsuarioAdminDTO dto);
        Task RemoveUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync();
    }
}
