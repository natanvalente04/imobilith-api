using alugueis_API.Handlers;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AddUsuarioHandler _AddUsuarioHandler;
        private readonly ExistsUsuarioHandler _ExistsUsuarioHandler;

        public UsuarioController(AddUsuarioHandler addUsuarioHandler, ExistsUsuarioHandler existsUsuarioHandler)
        {
            _AddUsuarioHandler = addUsuarioHandler;
            _ExistsUsuarioHandler = existsUsuarioHandler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioDTO dto)
        {
           return await _AddUsuarioHandler.Handle(dto);
        }

        [HttpGet]
        public Task<bool> ExistsUsuario()
        {
            return _ExistsUsuarioHandler.Handle();
        }
    }
}
