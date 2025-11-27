namespace alugueis_api.Models
{
    public enum EstadoCivil
    {
        Solteiro = 1,
        Casado = 2,
        Divorciado = 3,
        Viuvo = 4,
    }
    public class Pessoa
    {
        public int CodPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string Cpf { get; set; }
        public string Rg {  get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public Usuario Usuario { get; set; }

    }
}
