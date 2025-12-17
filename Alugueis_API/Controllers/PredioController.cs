using Alugueis_API.Data;
using Alugueis_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alugueis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredioController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;

        public PredioController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult>AddPredio(Predio predio)
        {
            _AppDbContext.Predios.Add(predio);
            await _AppDbContext.SaveChangesAsync();
            return Ok(predio);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Predio>>> GetPredios()
        {
            List<Predio> predios = await _AppDbContext.Predios.ToListAsync();
            return Ok(predios);
        }
        [HttpGet("{codPredio}")]
        public async Task<ActionResult<Predio>> GetPredioById(int codPredio)
        {
            Predio predio = await _AppDbContext.Predios.FindAsync(codPredio);
            if(predio == null) return NotFound();
            return Ok(predio);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Predio>> UpdatePredio([FromBody] Predio codPredioAtualizado)
        {
            Predio predioAtual = await _AppDbContext.Predios.FindAsync(codPredioAtualizado.CodPredio);
            if(predioAtual == null) return NotFound();
            _AppDbContext.Entry(predioAtual).CurrentValues.SetValues(codPredioAtualizado);
            await _AppDbContext.SaveChangesAsync();
            return Ok(predioAtual);
        }
        [HttpDelete("{codPredio}")]
        [Authorize]
        public async Task<IActionResult> DeletePredio(int codPredio)
        {
            Predio predio = await _AppDbContext.Predios.FindAsync(codPredio);
            if (predio == null) return NotFound();
            _AppDbContext.Predios.Remove(predio);
            await _AppDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
