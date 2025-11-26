using alugueis_api.Models;

namespace alugueis_api.Interfaces
{
    public interface IDespesaService
    {
        void RemoveRateiosDespesaAsync(Despesa despesa);
        Task RemoveDespesaAsync(Despesa despesa);
        Task<Despesa> ObterDespesaCompletaAsync(int codDespesa);
        Task RecalculaRateiosDespesaAsync(int codDespesa);
        void RateiaDespesa(Despesa despesa, List<Apto> aptos);
    }
}
