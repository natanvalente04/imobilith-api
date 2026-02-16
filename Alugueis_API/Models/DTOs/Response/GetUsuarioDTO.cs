namespace Alugueis_API.Models.DTOs.Response
{
    public class GetUsuarioDTO
    {
        public GetUsuarioDTO(int codUsuario, int codPessoa, Role role, bool ativo)
        {
            CodUsuario = codUsuario;
            CodPessoa = codPessoa;
            Role = role;
            Ativo = ativo;
        }

        public int CodUsuario { get; set; }
        public int CodPessoa { get; set; }
        public Role Role { get; set; }
        public bool Ativo { get; set; }
    }
}
