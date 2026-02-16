namespace Alugueis_API.Models.DTOs.Request
{
    public class AddLocatarioDTO
    {
        public int CodLocatario { get; set; }
        public int TemPet { get; set; }
        public int CodPessoa { get; set; }
        public int QtdDependentes { get; set; }
    }
}
