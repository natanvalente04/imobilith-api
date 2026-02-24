using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Repositories
{
    public class UsuarioRepository : IBaseRepository<Usuario>
    {
        private readonly AppDbContext _AppDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Add(Usuario usuario)
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

        public void Remove(Usuario usuario)
        {
            _AppDbContext.Usuarios.Remove(usuario);
        }

        public void Update(Usuario entity, Usuario updatedEntity)
        {
            _AppDbContext.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }

        public async Task SaveChangesAsync()
        {
           await _AppDbContext.SaveChangesAsync();
        }

        public async Task<Usuario> GetByLoginAsync(string login)
        {
            return await _AppDbContext.Usuarios
            .Include(u => u.Pessoa)
            .FirstOrDefaultAsync(u => u.Pessoa.Email == login);
        }

        public async Task<List<Usuario>> GetUsuarios(int? codUsuario = 0)
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (codUsuario == 0 || codUsuario == null)
            {
                usuarios = await GetAllAsync();
            }
            else
            {
                usuarios.Add(await GetAsync(codUsuario));
            }

            return usuarios;
        }

        public async Task<bool> Exists()
        {
            return await _AppDbContext.Usuarios.AnyAsync();
        }

        public async Task<Usuario> GetUsuarioByPessoaIdAsync(int codPessoa) 
        {
            Usuario usuario = await _AppDbContext.Usuarios.FirstOrDefaultAsync(u => u.CodPessoa == codPessoa); ;
            return usuario;
        }
    }
}
