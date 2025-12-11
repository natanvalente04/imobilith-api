using alugueis_api.Models.DTOs;
using alugueis_api.Models;

namespace alugueis_api.Interfaces
{
    public interface IPessoaService
    {
        Task AddPessoaAsync(PessoaDTO dto);
        Task RemovePessoaAsync(Pessoa pessoa);
        Task UpdatePessoaAsync(PessoaDTO dto);
    }
}
