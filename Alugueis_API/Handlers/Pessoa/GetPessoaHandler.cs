using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.PessoaHandlers
{
    public class GetPessoaHandler
    {
        private readonly IPessoaService _PessoaService;

        public GetPessoaHandler(IPessoaService pessoaService)
        {
            _PessoaService = pessoaService;
        }

        public async Task<ActionResult<List<PessoaDTO>>> Handle()
        {
            List<PessoaDTO> pessoasDTO = await _PessoaService.GetPessoasAsync();
            return new OkObjectResult(pessoasDTO);
        }
        public async Task<ActionResult<PessoaDTO>> HandleById(int? codPessoa)
        {
            PessoaDTO pessoaDTO = await _PessoaService.GetPessoaByIdAsync(codPessoa);
            return pessoaDTO;
        }
    }
}
