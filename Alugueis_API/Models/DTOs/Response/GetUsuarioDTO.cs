namespace Alugueis_API.Models.DTOs.Response
{
    public class GetUsuarioDTO
    {
        public int CodUsuario { get; set; }
        public int CodPessoa { get; set; }
        public Role Role { get; set; }
        public bool Ativo { get; set; }
    }
}
