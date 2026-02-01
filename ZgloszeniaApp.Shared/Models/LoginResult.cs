namespace ZgloszeniaApp.Shared.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
