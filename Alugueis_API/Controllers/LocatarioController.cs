using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatarioController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;
        private readonly IPessoaService _PessoaService;

        public LocatarioController(AppDbContext appDbContext, IPessoaService pessoaService)
        {
            _AppDbContext = appDbContext;
            _PessoaService = pessoaService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLocatario([FromBody] AddLocatarioDTO dto)
        {
            Locatario locatario = new Locatario (
                dto.CodLocatario,
                dto.CodPessoa,
                dto.TemPet,
                dto.QtdDependentes); 
            _AppDbContext.Locatarios.Add(locatario);
            await _AppDbContext.SaveChangesAsync();
            await _PessoaService.BindLocatarioAsync(dto.CodPessoa, locatario.CodLocatario);
            return Ok(locatario);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Locatario>>> GetLocatarios()
        {
            List<Locatario> locatarios = await _AppDbContext.Locatarios.ToListAsync();
            return Ok(locatarios);
        }
        [HttpGet("{codLocatario}")]
        [Authorize]
        public async Task<ActionResult<Locatario>> GetLocatarioById(int CodLocatario)
        {
            Locatario locatario = await _AppDbContext.Locatarios.FindAsync(CodLocatario);
            if (locatario == null) return NotFound();
            return Ok(locatario);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult>UpdateLocatario([FromBody] AddLocatarioDTO dto)
        {
            Locatario locatarioAtualizado = new Locatario(
                dto.CodLocatario,
                dto.CodPessoa,
                dto.TemPet,
                dto.QtdDependentes);
            Locatario locatarioAtual = await _AppDbContext.Locatarios.FindAsync(locatarioAtualizado.CodLocatario);
            if (locatarioAtual == null) return NotFound();
            _AppDbContext.Entry(locatarioAtual).CurrentValues.SetValues(locatarioAtualizado);
            await _AppDbContext.SaveChangesAsync();
            return Ok(locatarioAtual);
        }
        [HttpDelete("{CodLocatario}")]
        [Authorize]
        public async Task<IActionResult> DeleteLocatario(int CodLocatario)
        {
            Locatario locatario = await _AppDbContext.Locatarios.FindAsync(CodLocatario);
            if (locatario == null) return NotFound();
            _AppDbContext.Locatarios.Remove(locatario);
            await _AppDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
