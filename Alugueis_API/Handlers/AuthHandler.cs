using Alugueis_API.Interfaces;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers
{
    public class AuthHandler
    {
        private readonly IUsuarioService _UsuarioService;
        public AuthHandler(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }
        public async Task<GetAuthDTO> Handle(AuthDTO dto)
        {
             return await _UsuarioService.Autenticar(dto);
        }
    }
}
