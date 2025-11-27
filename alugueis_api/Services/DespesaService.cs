using alugueis_api.Interfaces;
using alugueis_api.Models;
using alugueis_api.NovaPasta;
using alugueis_api.Repositories;

namespace alugueis_api.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly DespesaRepository _DespesaRepository;
        private readonly AptoRepository _AptoRepository;


        public DespesaService(DespesaRepository despesaRepository, AptoRepository aptoRepository)
        {
            _DespesaRepository = despesaRepository;
            _AptoRepository = aptoRepository;
        }

        public async Task<Despesa> ObterDespesaCompletaAsync(int codDespesa)
        {
            Despesa despesa = await _DespesaRepository.GetDespesaById(codDespesa);
            await _DespesaRepository.GetDespesaRateios(despesa);
            return despesa;
        }
        public async Task RecalcularRateiosDespesasAsync(List<int> codDespesas)
        {
            foreach (int codDespesa in codDespesas) 
            {
                await RecalculaRateiosDespesaAsync(codDespesa);
            }
        }
        public async Task RecalculaRateiosDespesaAsync(int codDespesa)
        {
            Despesa despesa = await ObterDespesaCompletaAsync(codDespesa);
            List<Apto> aptos = await _AptoRepository.GetAptos();
            RemoveRateiosDespesaAsync(despesa);
            RateiaDespesa(despesa, aptos);
            await _DespesaRepository.SaveChangesAsync();
        }
        public void RateiaDespesa(Despesa despesa, List<Apto> aptos)
        {
            float valorRateio = despesa.VrlTotalDespesa / aptos.Count;
            foreach (Apto apto in aptos)
            {
                DespesaRateio despesaRateio = new DespesaRateio();
                despesaRateio.CodApto = apto.CodApto;
                despesaRateio.CodDespesa = despesa.CodDespesa;
                despesaRateio.VlrRateio = valorRateio;
                _DespesaRepository.AddRateio(despesaRateio);
            }
        }

        public async Task RemoveDespesaAsync(Despesa despesa)
        {
            RemoveRateiosDespesaAsync(despesa);
            _DespesaRepository.Remove(despesa);
            await _DespesaRepository.SaveChangesAsync();
        }


        public void RemoveRateiosDespesaAsync(Despesa despesa)
        {
            foreach (DespesaRateio despesaRateio in despesa.Rateios)
            {
                _DespesaRepository.RemoveRateio(despesaRateio);
            }
        }
    }
}
