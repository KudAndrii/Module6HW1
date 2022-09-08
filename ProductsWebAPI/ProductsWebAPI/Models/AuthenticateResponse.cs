namespace ProductsWebAPI.Models
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse(string login, string token)
        {
            Login = login;
            Token = token;
        }

        public string Login { get; init; }
        public string Token { get; init; }
    }
}
