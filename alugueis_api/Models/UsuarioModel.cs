namespace alugueis_api.Models
{

    public enum Role
    {
        Admin = 1,
        Locatario = 2
    }
    public class Usuario
    {
        public int CodUsuario {  get; set; }
        public int CodPessoa { get; set; }
        public Role Role { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public bool Ativo {  get; set; }
        public Pessoa Pessoa { get; set; }

    }
}
