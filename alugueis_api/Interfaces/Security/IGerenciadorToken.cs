using alugueis_api.Models;
using alugueis_api.Models.DTOs.Response;

namespace alugueis_api.Interfaces.Security
{
    public interface IGerenciadorToken
    {
        Task<GetAuthDTO> GenerateTokenAsync(Usuario usuario);
    }
}
