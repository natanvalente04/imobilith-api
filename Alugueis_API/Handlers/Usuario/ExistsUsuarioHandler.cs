using Alugueis_API.Interfaces;
using Alugueis_API.Repositories;

namespace Alugueis_API.Handlers.Usuario
{
    public class ExistsUsuarioHandler
    {
        private readonly IUsuarioService _UsuarioService;

        public ExistsUsuarioHandler(IUsuarioService usuarioService, UsuarioRepository usuarioRepository)
        {
            _UsuarioService = usuarioService;
        }

        public async Task<bool> Handle()
        {
            return await _UsuarioService.Existe();
        }
        public async Task<bool> HandleById(int codPessoa)
        {
            return await _UsuarioService.ExisteByPessoaId(codPessoa);
        }
    }
}
