using alugueis_api.Models;

namespace alugueis_api.Interfaces
{
    public interface IUsuarioService
    {
        Task CriaUsuarioAsync(Usuario usuario);

    }
}
