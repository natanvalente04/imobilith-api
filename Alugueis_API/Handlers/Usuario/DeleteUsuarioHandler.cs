using Alugueis_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.Usuario
{
    public class DeleteUsuarioHandler
    {
        private readonly IUsuarioService _UsuarioService;

        public DeleteUsuarioHandler(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        public async Task<IActionResult> Handle(int codUsuario)
        {
            return await _UsuarioService.RemoveUsuarioByIdAsync(codUsuario);
        }
    }
}