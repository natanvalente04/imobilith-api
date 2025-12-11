using alugueis_api.Interfaces;
using alugueis_api.Models;
using alugueis_api.Models.DTOs;
using alugueis_api.Repositories;
using System.Security;

namespace alugueis_api.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly PessoaRepository _PessoaRepository;
        public PessoaService(PessoaRepository pessoaRepository)
        {
            _PessoaRepository = pessoaRepository;
        }

        public async Task AddPessoaAsync(PessoaDTO dto)
        {
            Pessoa pessoa = CreatePessoa(dto);
            _PessoaRepository.Add(pessoa);
            await _PessoaRepository.SaveChangesAsync();
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
