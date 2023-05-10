using AutoMapper;
using MyGuides.Domain.Entities.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Domain.Entities.Users.Converters
{
    public class ToUserResultConverter : ITypeConverter<User, UserResult>
    {
        public UserResult Convert(User source, UserResult destination, ResolutionContext context) => (destination = new UserResult() { UserName = source.UserName, Email = source.Email, Password = source.Password });
    }
}
