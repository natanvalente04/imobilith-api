using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.Usuario
{
    public class UpdateUsuarioHandler
    {
        private readonly IUsuarioService _UsuarioService;

        public UpdateUsuarioHandler(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        public async Task<IActionResult> Handle(AddUsuarioDTO dto)
        {
            await _UsuarioService.UpdateUsuarioAsync(dto);
            return new OkObjectResult(null);
        }
    }
}