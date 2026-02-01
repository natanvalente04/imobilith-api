using alugueis_API.Handlers;
using Alugueis_API.Handlers;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly AddPessoaHandler _AddPessoaHandler;
        private readonly GetPessoaHandler _GetPessoaHandler;
        public PessoaController(AddPessoaHandler addPessoaHandler, GetPessoaHandler getPessoaHandler)
        {
            _AddPessoaHandler = addPessoaHandler;
            _GetPessoaHandler = getPessoaHandler;
        }

        [HttpPost]
        [Authorize]
        public Task<IActionResult> AddPessoa([FromBody] PessoaDTO dto)
        {
            return _AddPessoaHandler.Handle(dto);
        }
        [HttpGet]
        [Authorize]
        public Task<ActionResult<List<PessoaDTO>>> GetPessoa()
        {
            return _GetPessoaHandler.Handle();
        }
    }
}
