using MyGuides.Domain.Abstractions.Entities;
using System.ComponentModel.DataAnnotations; 

namespace MyGuides.Domain.Entities.Users;

public class User : Entity<Guid>
{ 
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }

    public override bool Validate()
    {
        return new UserValidator().Validate(this).IsValid;
    }
}
