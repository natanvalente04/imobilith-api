using alugueis_api.Data;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alugueis_api.Repositories
{
    public class AptoRepository : IBaseRepository<Apto>
    {
        private readonly AppDbContext _AppDbContext;
        public AptoRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void AddAsync(Apto apto)
        {
            _AppDbContext.Aptos.Add(apto);
        }

        public async Task<List<Apto>> GetAllAsync()
        {
            return await _AppDbContext.Aptos.ToListAsync();
        }

        public async Task<List<Apto>> GetAptos(int? codApto = 0)
        {
            List<Apto> aptos = new List<Apto>();

            if (codApto == 0 || codApto == null)
            {
                aptos = await GetAllAsync();
            }
            else
            {
                aptos.Add(await GetAsync(codApto));
            }

            return aptos;
        }

        public async Task<Apto> GetAsync(int? codApto)
        {
            Apto apto = await _AppDbContext.Aptos.FindAsync(codApto);
            return apto;
        }

        public void RemoveAsync(Apto apto)
        {
            _AppDbContext.Aptos.Remove(apto);
        }

        public async Task SaveChangesAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }
    }
}
