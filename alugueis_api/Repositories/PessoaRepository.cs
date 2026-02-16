using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Repositories
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

        public async Task BindLocatario(int codPessoa, int codLocatario)
        {
            await _AppDbContext.Pessoas.Where(p => p.CodPessoa == codPessoa).ExecuteUpdateAsync(setters => setters.SetProperty(p => p.CodLocatario, codLocatario));
        }
    }
}
