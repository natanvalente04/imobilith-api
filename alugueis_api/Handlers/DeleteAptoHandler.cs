using alugueis_api.Data;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using alugueis_api.NovaPasta;
using alugueis_api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace alugueis_api.Handlers
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
