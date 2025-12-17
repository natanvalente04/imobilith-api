namespace Alugueis_API.Models
{
    public class AuthConfig
    {
        public string Secret { get; set; }
        public int ExpireInHours { get; set; }
    }
}
