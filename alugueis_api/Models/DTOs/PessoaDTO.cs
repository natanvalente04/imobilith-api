namespace alugueis_api.Models.DTOs
{
    public class PessoaDTO
    {
        public int CodPessoa { get; set; }
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
