namespace alugueis_api.Models.DTOs
{
    public class UsuarioDTO
    {
        public int CodUsuario { get; set; }
        public int CodPessoa { get; set; }
        public Role Role { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
