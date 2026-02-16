using Alugueis_API.Data;
using Alugueis_API.Handlers.Despesa;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaAptoController : ControllerBase
    {
        private readonly AddDespesaAptoHandler _AddDespesaAptoHandler;
        private readonly UpdateDespesaAptoHandler _UpdateDespesaHandler;
        private readonly DeleteDespesaAptoHandler _DeleteDespesaAptoHandler;
        private readonly GetDespesaAptoHandler _GetDespesaAptoHandler;

        public DespesaAptoController(AddDespesaAptoHandler addDespesaHandler,
            UpdateDespesaAptoHandler updateDespesaHandler,
            DeleteDespesaAptoHandler deleteDespesaAptoHandler,
            GetDespesaAptoHandler getDespesaAptoHandler)
        {
            _AddDespesaAptoHandler = addDespesaHandler;
            _UpdateDespesaHandler = updateDespesaHandler;
            _DeleteDespesaAptoHandler = deleteDespesaAptoHandler;
            _GetDespesaAptoHandler= getDespesaAptoHandler;
        }

        [HttpPost]
        [Authorize]
        public Task<IActionResult> AddDespesaApto([FromBody] AddDespesaAptoDTO dto)
        {
            return _AddDespesaAptoHandler.Handle(dto);
        }

        [HttpGet]
        [Authorize]
        public Task<ActionResult<List<GetDespesaAptoDTO>>> GetDespesas()
        {
            return _GetDespesaAptoHandler.Handle();
        }

        [HttpPut]
        [Authorize]
        public Task<IActionResult> UpdateDespesa([FromBody] AddDespesaAptoDTO dto)
        {
            return _UpdateDespesaHandler.Handle(dto);
        }

        [HttpDelete("{codDespesa}")]
        [Authorize]
        public Task<IActionResult> DeleteDespesa(int codDespesa)
        {
            return _DeleteDespesaAptoHandler.Handle(codDespesa);
        }
    }
}
