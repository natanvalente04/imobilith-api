using Alugueis_API.Data;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.NovaPasta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Handlers.DespesaHandlers
{
    public class UpdateDespesaAptoHandler
    {
        private readonly DespesaRepository _DespesaRepository;

        public UpdateDespesaAptoHandler(AppDbContext appDbContext, DespesaRepository despesaRepository)
        {
            _DespesaRepository = despesaRepository;
        }

        public async Task<IActionResult> Handle(AddDespesaAptoDTO dto)
        {
            Despesa despesa = await _DespesaRepository.GetAsync(dto.CodDespesa);
            await _DespesaRepository.GetDespesaRateios(despesa);
            await _DespesaRepository.GetTipoDespesaDespesa(despesa);
            UpdateDespesa(despesa, dto);
            await _DespesaRepository.SaveChangesAsync();
            GetDespesaAptoDTO getDespesaAptoDTO = new GetDespesaAptoDTO(
                despesa.CodDespesa,
                despesa.CodTipoDespesa,
                despesa.TipoDespesa.NomeTipoDespesa,
                despesa.VrlTotalDespesa,
                despesa.DataDespesa,
                despesa.CompetenciaMes,
                despesa.TipoDespesa.Compartilhado
                );
            return new OkObjectResult(getDespesaAptoDTO);
        }

        private void UpdateDespesa(Despesa despesa, AddDespesaAptoDTO dto)
        {
            despesa.VrlTotalDespesa = dto.VlrTotalDespesa;
            despesa.CompetenciaMes = dto.CompetenciaMes;
            UpdateDespesaRateios(despesa);
        }

        private void UpdateDespesaRateios(Despesa despesa)
        {
            float valorRateio = despesa.VrlTotalDespesa / despesa.Rateios.Count;
            foreach (DespesaRateio rateio in despesa.Rateios)
            {
                rateio.VlrRateio = valorRateio;
            }
        }

    }
}
