using Alugueis_API.Data;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.NovaPasta;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers
{
    public class GetDespesaAptoHandler
    {
        private readonly DespesaRepository _DespesaRepository;

        public GetDespesaAptoHandler(DespesaRepository despesaRepository)
        {
            _DespesaRepository = despesaRepository;
        }

        public async Task<ActionResult<List<GetDespesaAptoDTO>>> Handle()
        {
            List<GetDespesaAptoDTO> DespesasDTO = await GetDespesasDTO();
            return new OkObjectResult(DespesasDTO);
        }

        public async Task<List<GetDespesaAptoDTO>> GetDespesasDTO()
        {
            List<Despesa> despesas = await _DespesaRepository.GetDespesas();

            await _DespesaRepository.GetTipoDespesaDespesas(despesas);
            List<GetDespesaAptoDTO> despesasAptoDTO = new List<GetDespesaAptoDTO>();
            foreach(Despesa despesa in despesas)
            {
                despesasAptoDTO.Add(new GetDespesaAptoDTO(
                    despesa.CodDespesa,
                    despesa.CodTipoDespesa,
                    despesa.TipoDespesa.NomeTipoDespesa,
                    despesa.VrlTotalDespesa,
                    despesa.DataDespesa,
                    despesa.CompetenciaMes,
                    despesa.TipoDespesa.Compartilhado
                ));
            }
            return despesasAptoDTO;
        }
    }
}
