using Alugueis_API.Handlers;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthHandler _AuthHandler;
        private readonly RegisterLoginHandler _RegisterLoginHandler;
        public AuthController(AuthHandler authHandler, RegisterLoginHandler registerLoginHandler)
        {
            _AuthHandler = authHandler;
            _RegisterLoginHandler = registerLoginHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthDTO dto)
        {
            GetAuthDTO result =  await _AuthHandler.Handle(dto);
            if (result == null) return Unauthorized();
            return Ok(result);
        }
        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {

            return await _RegisterLoginHandler.Handle(dto);
        }
    }
}
