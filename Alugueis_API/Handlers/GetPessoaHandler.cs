using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers
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
    }
}
