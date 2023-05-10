using MediatR; 
using MyGuides.Domain.Entities.Users.Results;

namespace MyGuides.Domain.Entities.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<UserResult>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
         
        public AddUserCommand(string name, string email, string password)
        {
            UserName = name;
            Email = email;
            Password = password;
        }

        public AddUserCommand()
        {
        }
    }
}
