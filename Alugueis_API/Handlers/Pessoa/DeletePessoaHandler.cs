using Alugueis_API.Interfaces;
using Alugueis_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.PessoaHandlers
{
    public class DeletePessoaHandler
    {
        private IPessoaService _PessoaService;

        public DeletePessoaHandler(IPessoaService pessoaService)
        {
            _PessoaService = pessoaService;
        }

        public async Task<ActionResult> Handle(int codPessoa)
        {
            return await _PessoaService.RemovePessoaByIdAsync(codPessoa);
        }
    }
}
