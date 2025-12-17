namespace Alugueis_API.Models.DTOs.Response
{
    public class GetAuthDTO
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public int ExpireIn { get; set; }
    }
}
