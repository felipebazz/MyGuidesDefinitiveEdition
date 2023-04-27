using AutoMapper;

namespace MyGuides.Domain.Entities.Achievements.Converters
{
    public class StoreToAchievementConverter : ITypeConverter<Tuple<IEnumerable<Steam.Api.Responses.Achievement>, Guid>, List<Achievement>>
    {
        public List<Achievement> Convert(Tuple<IEnumerable<Steam.Api.Responses.Achievement>, Guid> source, List<Achievement> destination, ResolutionContext context)
        {
            return source.Item1.Select(achievement => new Achievement
            (
                Guid.NewGuid(),
                achievement.Name,
                achievement.Hidden == 0 ? achievement.Description : "",
                achievement.DisplayName,
                achievement.Hidden == 1 ? true : false,
                achievement.Icon,
                achievement.Icongray,
                source.Item2
            )).ToList();
        }
    }
}

