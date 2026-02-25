using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.NovaPasta;
using Alugueis_API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.AptoHandlers
{
    public class DeleteAptoHandler
    {

        private readonly AptoRepository _AptoRepository;
        private readonly DespesaRepository _DespesaRepository;
        private readonly IDespesaService _DespesaService;

        public DeleteAptoHandler(AptoRepository aptoRepository, DespesaRepository despesaRepository, IDespesaService despesaService)
        {
            _AptoRepository = aptoRepository;
            _DespesaRepository = despesaRepository;
            _DespesaService = despesaService;
        }
        public async Task<IActionResult> Handle(int codApto)
        {
            Apto apto = await _AptoRepository.GetAsync(codApto);
            if (apto == null) return new OkObjectResult(null);
            List<int> codDespesas = await _DespesaRepository.GetCodDespesasRecalcular(codApto);
            _AptoRepository.Remove(apto);
            await _AptoRepository.SaveChangesAsync();
            await _DespesaService.RecalcularRateiosDespesasAsync(codDespesas);
            return new OkObjectResult(null);
        }
    }
}
