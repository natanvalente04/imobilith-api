namespace Alugueis_API.Models.DTOs
{
    public class UsuarioDTO
    {
        public int CodUsuario { get; set; }
        public int CodPessoa { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
