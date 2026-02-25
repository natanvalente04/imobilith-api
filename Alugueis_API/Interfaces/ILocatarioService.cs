using Alugueis_API.Models.DTOs.Response;

namespace Alugueis_API.Interfaces
{
    public interface ILocatarioService
    {
        public Task<List<GetLocatarioDTO>> GetLocatariosAsync();
    }
}
