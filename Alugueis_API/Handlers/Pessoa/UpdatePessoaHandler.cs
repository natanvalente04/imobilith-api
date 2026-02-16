using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.Pessoa
{
    public class UpdatePessoaHandler
    {
        private readonly IPessoaService _pessoaService;

        public UpdatePessoaHandler(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<ActionResult> Handle(PessoaDTO dto)
        {
            await _pessoaService.UpdatePessoaAsync(dto);
            return new OkObjectResult(null);
        }
    }
}
