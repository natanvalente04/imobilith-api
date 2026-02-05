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
        private readonly UpdatePessoaHandler _UpdatePessoaHandler;
        private readonly DeletePessoaHandler _DeletePessoaHandler;
        public PessoaController(AddPessoaHandler addPessoaHandler, GetPessoaHandler getPessoaHandler, UpdatePessoaHandler updatePessoaHandler, DeletePessoaHandler deletePessoaHandler)
        {
            _AddPessoaHandler = addPessoaHandler;
            _GetPessoaHandler = getPessoaHandler;
            _UpdatePessoaHandler = updatePessoaHandler;
            _DeletePessoaHandler = deletePessoaHandler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPessoa([FromBody] PessoaDTO dto)
        {
            return await _AddPessoaHandler.Handle(dto);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PessoaDTO>>> GetPessoas()
        {
            return await _GetPessoaHandler.Handle();
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePessoa([FromBody] PessoaDTO dto)
        {
            return await _UpdatePessoaHandler.Handle(dto);
        }
        [HttpDelete("{codPessoa}")]
        [Authorize]
        public async Task<ActionResult> DeletePessoa(int codPessoa)
        {
            return await _DeletePessoaHandler.Handle(codPessoa);
        }
    }
}
