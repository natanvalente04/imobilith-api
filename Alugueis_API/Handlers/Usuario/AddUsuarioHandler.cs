using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.Usuario
{
    public class AddUsuarioHandler
    {
        private readonly IUsuarioService _UsuarioService;

        public AddUsuarioHandler(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        public async Task<IActionResult> Handle(AddUsuarioDTO dto)
        {
            Models.Usuario usuario = await _UsuarioService.AddUsuarioAsync(dto);
            return new OkObjectResult(usuario);
        }
    }
}
