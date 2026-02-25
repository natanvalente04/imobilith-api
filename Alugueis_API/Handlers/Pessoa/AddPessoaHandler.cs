using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.PessoaHandlers
{
    public class AddPessoaHandler
    {
        private readonly IPessoaService _pessoaService;

        public AddPessoaHandler(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<IActionResult> Handle(PessoaDTO dto)
        {
            Pessoa pessoa =  await _pessoaService.AddPessoaAsync(dto);
            return new OkObjectResult(pessoa);
        }
    }
}
