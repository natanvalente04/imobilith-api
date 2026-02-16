namespace Alugueis_API.Models.DTOs
{
    public class PessoaDTO
    {
        public PessoaDTO(int codPessoa, int codLocatario, string nomePessoa, string cpf, string rg, string endereco, string telefone, string email, EstadoCivil estadoCivil, DateTime dataNascimento)
        {
            CodPessoa = codPessoa;
            CodLocatario = codLocatario;
            NomePessoa = nomePessoa;
            Cpf = cpf;
            Rg = rg;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            EstadoCivil = estadoCivil;
            DataNascimento = dataNascimento;
        }

        public int CodPessoa { get; set; }
        public int CodLocatario { get; set; }
        public string NomePessoa { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
