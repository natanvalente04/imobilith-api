using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.NovaPasta;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers
{
    public class DeleteDespesaAptoHandler
    {

        private readonly IDespesaService _DespesaService;
        public DeleteDespesaAptoHandler(IDespesaService despesaService)
        {
            _DespesaService = despesaService;
        }

        public async Task<IActionResult> Handle(int codDespesa)
        {
            Despesa despesa = await _DespesaService.ObterDespesaCompletaAsync(codDespesa);
            await _DespesaService.RemoveDespesaAsync(despesa);
            return new OkObjectResult(null);
        }
    }
}
