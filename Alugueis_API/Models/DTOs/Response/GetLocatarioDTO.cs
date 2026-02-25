namespace Alugueis_API.Models.DTOs.Response
{
    public class GetLocatarioDTO
    {
        public GetLocatarioDTO(int codLocatario, int temPet, int codPessoa, int qtdDependentes, PessoaDTO pessoa)
        {
            CodLocatario = codLocatario;
            TemPet = temPet;
            CodPessoa = codPessoa;
            QtdDependentes = qtdDependentes;
            Pessoa = pessoa;
        }

        public int CodLocatario { get; set; }
        public int TemPet { get; set; }
        public int CodPessoa { get; set; }
        public int QtdDependentes { get; set; }
        public PessoaDTO Pessoa { get; set; }
    }
}
