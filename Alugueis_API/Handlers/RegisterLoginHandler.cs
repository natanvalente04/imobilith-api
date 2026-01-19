using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alugueis_API.Handlers
{
    public class RegisterLoginHandler
    {
        private readonly IUsuarioService _UsuarioService;
        private readonly IPessoaService _PessoaService;
        private readonly IMapper _Mapper;

        public RegisterLoginHandler(IUsuarioService usuarioService, IPessoaService pessoaService, IMapper mapper)
        {
            _UsuarioService = usuarioService;
            _PessoaService = pessoaService;
            _Mapper = mapper;
        }

        public async Task<IActionResult> Handle(RegisterDTO dto)
        {
            if (await _UsuarioService.Existe(dto.Usuario.CodUsuario)) return null;

            Pessoa pessoa = await _PessoaService.AddPessoaAsync(dto.Pessoa);
            dto.Usuario.CodPessoa = pessoa.CodPessoa;
            Usuario usuario = await _UsuarioService.AddUsuarioAsync(dto.Usuario);
            GetUsuarioDTO usuarioDTO = _Mapper.Map<GetUsuarioDTO>(usuario);
            return new OkObjectResult(usuarioDTO);
        }
    }
}
