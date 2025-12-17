using alugueis_API.Handlers;
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
        public PessoaController(AddPessoaHandler addPessoaHandler)
        {
            _AddPessoaHandler = addPessoaHandler;
        }

        [HttpPost]
        [Authorize]
        public Task<IActionResult> AddPessoa([FromBody] PessoaDTO dto)
        {
            return _AddPessoaHandler.Handle(dto);
        }
    }
}
