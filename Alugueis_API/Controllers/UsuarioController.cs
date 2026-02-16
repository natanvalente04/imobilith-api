using Alugueis_API.Handlers.Usuario;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AddUsuarioHandler _AddUsuarioHandler;
        private readonly ExistsUsuarioHandler _ExistsUsuarioHandler;
        private readonly GetUsuarioHandler _GetUsuarioHandler;
        private readonly UpdateUsuarioHandler _UpdateUsuarioHandler;
        private readonly DeleteUsuarioHandler _DeleteUsuarioHandler;

        public UsuarioController(AddUsuarioHandler addUsuarioHandler,
            ExistsUsuarioHandler existsUsuarioHandler,
            GetUsuarioHandler getUsuarioHandler,
            UpdateUsuarioHandler updateUsuarioHandler,
            DeleteUsuarioHandler deleteUsuarioHandler)
        {
            _AddUsuarioHandler = addUsuarioHandler;
            _ExistsUsuarioHandler = existsUsuarioHandler;
            _GetUsuarioHandler = getUsuarioHandler;
            _UpdateUsuarioHandler = updateUsuarioHandler;
            _DeleteUsuarioHandler = deleteUsuarioHandler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUsuario([FromBody] AddUsuarioDTO dto)
        {
            return await _AddUsuarioHandler.Handle(dto);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GetUsuarioDTO>>> GetUsuario()
        {
            return await _GetUsuarioHandler.Handle();
        }

        [HttpGet("{codUsuario}")]
        [Authorize]
        public async Task<ActionResult<List<GetUsuarioDTO>>> GetUsuarioById(int? codUsuario)
        {
            return await _GetUsuarioHandler.HandleById(codUsuario);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUsuario([FromBody] AddUsuarioDTO dto)
        {
            return await _UpdateUsuarioHandler.Handle(dto);
        }

        [HttpDelete("{codUsuario}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsuario(int codUsuario)
        {
            return await _DeleteUsuarioHandler.Handle(codUsuario);
        }


        [HttpGet("existe")]
        public async Task<IActionResult> ExistsUsuario()
        {
            return Ok(await _ExistsUsuarioHandler.Handle());
        }
    }
}
