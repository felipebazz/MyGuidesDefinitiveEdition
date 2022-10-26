using AutoMapper;

namespace MyGuides.Domain.Entities.Achievements.Converters
{
    public class AchievementsConverter : ITypeConverter<List<Steam.Api.Responses.Achievement>, List<Achievement>>
    {
        public List<Achievement> Convert(List<Steam.Api.Responses.Achievement> source, List<Achievement> destination, ResolutionContext context)
        {
            destination.Clear();

            foreach (var achievement in source)
            {
                destination.Add(new Achievement(
                    Guid.NewGuid(),
                    achievement.Name,
                    achievement.Description,
                    achievement.DisplayName,
                    achievement.Hidden == 1 ? true : false,
                    achievement.Icon,
                    achievement.Icongray));
            }

            return destination;
        }
    }
}
