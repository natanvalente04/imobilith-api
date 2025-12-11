using alugueis_api.Data;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alugueis_api.Repositories
{
    public class PessoaRepository : IBaseRepository<Pessoa>
    {
        private readonly AppDbContext _AppDbContext;
        public PessoaRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }
        public void Add(Pessoa entity)
        {
            _AppDbContext.Pessoas.Add(entity);
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _AppDbContext.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetAsync(int? id)
        {
            Pessoa pessoa = await _AppDbContext.Pessoas.FindAsync(id);
            return pessoa;
        }

        public void Remove(Pessoa entity)
        {
            _AppDbContext.Pessoas.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }

        public void Update(Pessoa entity, Pessoa updatedEntity)
        {
            _AppDbContext.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }
    }
}
