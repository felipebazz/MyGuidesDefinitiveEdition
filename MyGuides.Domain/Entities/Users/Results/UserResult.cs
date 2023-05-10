using Microsoft.AspNetCore.Identity;

namespace MyGuides.Domain.Entities.Users.Results
{
    public class UserResult : IdentityUser
    { 
        public string Password { get; set; } = string.Empty;
    }
}
