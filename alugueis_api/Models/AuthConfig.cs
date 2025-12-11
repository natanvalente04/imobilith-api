namespace alugueis_api.Models
{
    public class AuthConfig
    {
        public string Secret { get; set; }
        public int ExpireInHours { get; set; }
    }
}
