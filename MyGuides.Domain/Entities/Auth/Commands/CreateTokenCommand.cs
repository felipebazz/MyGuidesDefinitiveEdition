using MediatR;
using MyGuides.Domain.Entities.Auth.Results;
using System.ComponentModel.DataAnnotations;

namespace MyGuides.Domain.Entities.Auth.Commands
{
    public class CreateTokenCommand : IRequest<AuthResult>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
