namespace Alugueis_API.Models
{

    public enum Role
    {
        Admin,
        Locatario
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
