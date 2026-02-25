
using Alugueis_API.Data;
using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers.LocatarioHandlers
{
    public class GetLocatarioHandler
    {
        private readonly ILocatarioService _LocatarioService;

        public GetLocatarioHandler(ILocatarioService locatarioService)
        {
            _LocatarioService = locatarioService;
        }

        internal async Task<ActionResult<List<GetLocatarioDTO>>> Handle()
        {
            return new OkObjectResult(await _LocatarioService.GetLocatariosAsync());
        }
    }
}
