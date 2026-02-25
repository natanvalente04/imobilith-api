using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Repositories
{
    public class LocatarioRepository : IBaseRepository<Locatario>
    {
        private readonly AppDbContext _AppDbContext;

        public LocatarioRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Add(Locatario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Locatario>> GetAllAsync()
        {
            return await _AppDbContext.Locatarios.ToListAsync();
        }

        public Task<Locatario> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Locatario entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Locatario entity, Locatario updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
