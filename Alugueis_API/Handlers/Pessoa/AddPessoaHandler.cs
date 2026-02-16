using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.Pessoa
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
            Models.Pessoa pessoa =  await _pessoaService.AddPessoaAsync(dto);
            return new OkObjectResult(pessoa);
        }
    }
}
