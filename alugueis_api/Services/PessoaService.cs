using Alugueis_API.Interfaces;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs;
using Alugueis_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace Alugueis_API.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly PessoaRepository _PessoaRepository;
        public PessoaService(PessoaRepository pessoaRepository)
        {
            _PessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> AddPessoaAsync(PessoaDTO dto)
        {
            Pessoa pessoa = CreatePessoa(dto);
            _PessoaRepository.Add(pessoa);
            await _PessoaRepository.SaveChangesAsync();
            return pessoa;
        }

        public async Task RemovePessoaAsync(Pessoa pessoa)
        {
            _PessoaRepository.Remove(pessoa);
            await _PessoaRepository.SaveChangesAsync();
        }

        public async Task UpdatePessoaAsync(PessoaDTO dto)
        {
            Pessoa pessoa = await _PessoaRepository.GetAsync(dto.CodPessoa);
            Pessoa pessoaAtualizada = CreatePessoa(dto);
            if (pessoa == null) return;
            if (pessoa == null) return;
            _PessoaRepository.Update(pessoa, pessoaAtualizada);
            await _PessoaRepository.SaveChangesAsync();
        }

        public async Task<List<PessoaDTO>> GetPessoasAsync()
        {
            List<Pessoa> pessoas = await _PessoaRepository.GetAllAsync();
            return GetPessoaDTO(pessoas);
        }
        public async Task<ActionResult> RemovePessoaByIdAsync(int codPessoa)
        {
            Pessoa pessoa = await _PessoaRepository.GetAsync(codPessoa);
            if (pessoa == null) return new OkObjectResult(null);
            await RemovePessoaAsync(pessoa);
            return new OkObjectResult(null);
        }
        private List<PessoaDTO> GetPessoaDTO(List<Pessoa> pessoas)
        {
            List<PessoaDTO> pessoasDTO = new List<PessoaDTO>();
            foreach(Pessoa pessoa in pessoas)
            {
                pessoasDTO.Add(new PessoaDTO(
                    pessoa.CodPessoa,
                    pessoa.NomePessoa,
                    pessoa.Cpf,
                    pessoa.Rg,
                    pessoa.Endereco,
                    pessoa.Telefone,
                    pessoa.Email,
                    pessoa.EstadoCivil,
                    pessoa.DataNascimento
                ));
            }
            return pessoasDTO;
        }
        public Pessoa CreatePessoa(PessoaDTO dto)
        {
            Pessoa pessoa = new Pessoa
            {
                CodPessoa = dto.CodPessoa,
                NomePessoa = dto.NomePessoa,
                Cpf = dto.Cpf,
                Rg = dto.Rg,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                EstadoCivil = dto.EstadoCivil,
                DataNascimento = dto.DataNascimento,
            };
            return pessoa;
        }
    }
}
