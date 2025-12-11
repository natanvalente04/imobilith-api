using alugueis_api.Data;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace alugueis_api.NovaPasta
{
    public class DespesaRepository : IBaseRepository<Despesa>
    {
        private readonly AppDbContext _AppDbContext;

        public DespesaRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }
        public void Add(Despesa despesa)
        {
            _AppDbContext.Despesas.Add(despesa);
        }
        public void Remove(Despesa despesa)
        {
            _AppDbContext.Despesas.Remove(despesa);
        }
        public void Update(Despesa entity, Despesa updatedEntity)
        {
            throw new NotImplementedException();
        }
        public async Task<Despesa> GetAsync(int? id)
        {
            Despesa despesa = await _AppDbContext.Despesas.FindAsync(id);
            return despesa;
        }
        public async Task<List<Despesa>> GetAllAsync()
        {
            return await _AppDbContext.Despesas.ToListAsync();
        }
        public void RemoveRateio(DespesaRateio despesaRateio)
        {
            _AppDbContext.DespesaRateios.Remove(despesaRateio);
        }
        public void AddRateio(DespesaRateio despesaRateio)
        {
            _AppDbContext.DespesaRateios.Add(despesaRateio);
        }
        private async Task<DespesaRateio> GetDespesaRateioById(int codDespesaRateio)
        {
            DespesaRateio tipoDespesa = await _AppDbContext.DespesaRateios.FindAsync(codDespesaRateio);
            return tipoDespesa;
        }
        public async Task GetDespesaRateios(Despesa despesa)
        {
            await _AppDbContext.Entry(despesa).Collection(d => d.Rateios).LoadAsync();
        }
        public async Task GetTipoDespesaDespesa(Despesa despesa)
        {
            await _AppDbContext.Entry(despesa).Reference(d => d.TipoDespesa).LoadAsync();
        }
        public async Task GetTipoDespesaDespesas(List<Despesa> despesas)
        {

            List<Despesa> despesasComTipo = await _AppDbContext.Despesas
            .Include(d => d.TipoDespesa)
            .ToListAsync();

            foreach (var despesa in despesas)
            {
                despesa.TipoDespesa = despesasComTipo
                    .FirstOrDefault(x => x.CodDespesa == despesa.CodDespesa)
                    .TipoDespesa;
            }
        }
        public async Task<List<Despesa>> GetDespesas(int? codDespesa = 0)
        {
            List<Despesa> despesas = new List<Despesa>();

            if (codDespesa == 0 || codDespesa == null)
            {
                despesas = await GetAllAsync();
            }
            else
            {
                despesas.Add(await GetAsync(codDespesa));
            }

            return despesas;
        }
        public async Task<List<int>> GetCodDespesasRecalcular(int codApto)
        {
            return await _AppDbContext.DespesaRateios
                .Include(dr => dr.Despesa)
                    .ThenInclude(d => d.TipoDespesa)
                .Where(dr => dr.CodApto == codApto)
                .Where(dr => dr.Despesa.TipoDespesa.Compartilhado == 1)
                .Select(dr => dr.CodDespesa)
            .Distinct()
                .ToListAsync();
        }
    }
}
