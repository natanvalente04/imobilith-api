namespace alugueis_api.Models.DTOs
{
    public class AddUsuarioAdminDTO
    {
        public int CodUsuario { get; set; }
        public int CodPessoa { get; set; }
        public Role Role { get; set; } = Role.Admin;
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
