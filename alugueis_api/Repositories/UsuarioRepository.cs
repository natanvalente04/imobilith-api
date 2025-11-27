using alugueis_api.Data;
using alugueis_api.Interfaces;
using alugueis_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alugueis_api.Repositories
{
    public class UsuarioRepository : IBaseRepository<Usuario>
    {
        private readonly AppDbContext _AppDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void AddAsync(Usuario usuario)
        {
            _AppDbContext.Usuarios.Add(usuario);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _AppDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetAsync(int? codUsuario)
        {
            Usuario usuario = await _AppDbContext.Usuarios.FindAsync(codUsuario);
            return usuario;
        }

        public void RemoveAsync(Usuario usuario)
        {
            _AppDbContext.Usuarios.Remove(usuario);
        }

        public async Task SaveChangesAsync()
        {
           await _AppDbContext.SaveChangesAsync();
        }
    }
}
