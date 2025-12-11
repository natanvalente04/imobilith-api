using alugueis_api.Data;
using alugueis_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace alugueis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatarioController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;

        public LocatarioController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocatario([FromBody] Locatario locatario)
        {
            _AppDbContext.Locatarios.Add(locatario);
            await _AppDbContext.SaveChangesAsync();
            return Ok(locatario);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locatario>>> GetLocatarios()
        {
            List<Locatario> locatarios = await _AppDbContext.Locatarios.ToListAsync();
            return Ok(locatarios);
        }
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Locatario>> GetLocatarioById(int CodLocatario)
        {
            Locatario locatario = await _AppDbContext.Locatarios.FindAsync(CodLocatario);
            if (locatario == null) return NotFound();
            return Ok(locatario);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateLocatario([FromBody] Locatario locatarioAtualizado)
        {
            Locatario locatarioAtual = await _AppDbContext.Locatarios.FindAsync(locatarioAtualizado.CodLocatario);
            if (locatarioAtual == null) return NotFound();
            _AppDbContext.Entry(locatarioAtual).CurrentValues.SetValues(locatarioAtualizado);
            await _AppDbContext.SaveChangesAsync();
            return Ok(locatarioAtual);
        }
        [HttpDelete("{CodLocatario}")]
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
