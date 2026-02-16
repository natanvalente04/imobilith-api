using System.ComponentModel.DataAnnotations;

namespace Alugueis_API.Models
{
    public class Locatario
    {
        public Locatario(int codLocatario, int codPessoa, int temPet, int qtdDependentes)
        {
            CodLocatario = codLocatario;
            CodPessoa = codPessoa;
            TemPet = temPet;
            QtdDependentes = qtdDependentes;
        }

        public int CodLocatario { get; set; }
        public int TemPet {  get; set; }
        public int CodPessoa { get; set; }
        public int QtdDependentes { get; set; }
        public ICollection<Locacao> Locacoes { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
