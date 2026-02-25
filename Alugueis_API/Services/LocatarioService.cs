using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Models.DTOs.Response;

namespace Alugueis_API.Services
{
    public class LocatarioService : ILocatarioService
    {
        private readonly IBaseRepository<Locatario> _LocatarioRepository;
        private readonly IPessoaService _PessoaService;

        public LocatarioService(IPessoaService pessoaService, IBaseRepository<Locatario> locatarioRepository)
        {
            _PessoaService = pessoaService;
            _LocatarioRepository = locatarioRepository;
        }

        public async Task<List<GetLocatarioDTO>> GetLocatariosAsync()
        {
            List<Locatario> locatarios = await _LocatarioRepository.GetAllAsync();
            return await GetLocatariosDTO(locatarios);

        }

        private async Task<List<GetLocatarioDTO>> GetLocatariosDTO(List<Locatario> locatarios)
        {
            List<GetLocatarioDTO> locatariosDTO = new List<GetLocatarioDTO>();
            foreach (Locatario locatario in locatarios)
            {
                PessoaDTO pessoaDTO = await _PessoaService.GetPessoaByIdAsync(locatario.CodPessoa);
                locatariosDTO.Add(GetLocatarioDTO(locatario, pessoaDTO));
            }
            return locatariosDTO;
        }
        private GetLocatarioDTO GetLocatarioDTO(Locatario locatario, PessoaDTO pessoaDTO) 
        {
            return new GetLocatarioDTO(
                locatario.CodLocatario,
                locatario.CodPessoa,
                locatario.TemPet,
                locatario.QtdDependentes,
                pessoaDTO
            );
        }
    }
}
