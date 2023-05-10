namespace MyGuides.Domain.Entities.Auth.Results;

public class AuthResult
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}
