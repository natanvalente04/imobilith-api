using Alugueis_API.Models;

namespace Alugueis_API.Interfaces
{
    public interface IDespesaService
    {
        void RemoveRateiosDespesaAsync(Despesa despesa);
        Task RemoveDespesaAsync(Despesa despesa);
        Task<Despesa> ObterDespesaCompletaAsync(int codDespesa);
        Task RecalcularRateiosDespesasAsync(List<int> codDespesas);
        Task RecalculaRateiosDespesaAsync(int codDespesa);
        void RateiaDespesa(Despesa despesa, List<Apto> aptos);
    }
}
