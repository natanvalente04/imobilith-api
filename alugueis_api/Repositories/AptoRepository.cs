using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Repositories
{
    public class AptoRepository : IBaseRepository<Apto>
    {
        private readonly AppDbContext _AppDbContext;
        public AptoRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Add(Apto apto)
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

        public void Remove(Apto apto)
        {
            _AppDbContext.Aptos.Remove(apto);
        }

        public async Task SaveChangesAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }

        public void Update(Apto entity, Apto updatedEntity)
        {
            _AppDbContext.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }
    }
}
