using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Interfaces
{
    public interface IPessoaService
    {
        Task<Pessoa> AddPessoaAsync(PessoaDTO dto);
        Task RemovePessoaAsync(Pessoa pessoa);
        Task UpdatePessoaAsync(PessoaDTO dto);
        Task<List<PessoaDTO>> GetPessoasAsync();
    }
}
