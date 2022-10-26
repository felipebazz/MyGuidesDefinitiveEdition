using AutoMapper;
using MyGuides.Domain.Entities.Achievements;

namespace MyGuides.Application.UseCases.Games.AddGame.Converters
{
    public class SteamAchievementsConverter : ITypeConverter<List<Steam.Api.Responses.Achievement>, List<Achievement>>
    {
        public List<Achievement> Convert(List<Steam.Api.Responses.Achievement> source, List<Achievement> destination, ResolutionContext context)
        {
            destination = new List<Achievement>();

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
