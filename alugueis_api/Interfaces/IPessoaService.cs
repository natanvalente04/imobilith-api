using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Interfaces
{
    public interface IPessoaService
    {
        Task<Pessoa> AddPessoaAsync(PessoaDTO dto);
        Task RemovePessoaAsync(Pessoa pessoa);
        Task<ActionResult> RemovePessoaByIdAsync(int codPessoa);
        Task UpdatePessoaAsync(PessoaDTO dto);
        Task<List<PessoaDTO>> GetPessoasAsync();
        Task<PessoaDTO> GetPessoaByIdAsync(int? codPessoa);
        Task BindLocatarioAsync(int codPessoa, int codLocatario);
    }
}
