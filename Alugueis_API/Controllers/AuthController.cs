using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Alugueis_API.Services;
using Alugueis_API.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alugueis_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthHandler _AuthHandler;
        public AuthController(AuthHandler authHandler)
        {
            _AuthHandler = authHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthDTO dto)
        {
            GetAuthDTO result =  await _AuthHandler.Handle(dto);
            if (result == null) return Unauthorized();
            return Ok(result);
        }
    }
}
