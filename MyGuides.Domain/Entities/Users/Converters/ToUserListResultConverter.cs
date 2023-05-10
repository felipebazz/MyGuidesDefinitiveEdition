using AutoMapper;
using MyGuides.Domain.Entities.Users.Results;

namespace MyGuides.Domain.Entities.Users.Converters;

public class ToUserListResultConverter : ITypeConverter<List<User>, List<UserResult>>
{
    public List<UserResult> Convert(List<User> source, List<UserResult> destination, ResolutionContext context) => 
        source.Select(x => new UserResult()
            {
                Email = x.Email,
                UserName = x.UserName,
                Password = x.Password
            })
        .ToList();
}
