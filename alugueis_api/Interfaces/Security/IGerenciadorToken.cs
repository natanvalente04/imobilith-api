using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Response;

namespace Alugueis_API.Interfaces.Security
{
    public interface IGerenciadorToken
    {
        Task<GetAuthDTO> GenerateTokenAsync(Usuario usuario);
    }
}
