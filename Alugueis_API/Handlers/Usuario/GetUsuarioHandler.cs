using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.UsuarioHandlers
{
    public class GetUsuarioHandler
    {
        private readonly IUsuarioService _UsuarioService;
        public GetUsuarioHandler(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }
        public async Task<ActionResult<List<GetUsuarioDTO>>> Handle()
        {
            return new OkObjectResult(await _UsuarioService.GetUsuarios());
        }

        internal async Task<ActionResult<List<GetUsuarioDTO>>> HandleById(int? codUsuario)
        {
            return new OkObjectResult(await _UsuarioService.GetUsuarioById(codUsuario));
        }
    }
}
