using AutoMapper;
using MyGuides.Domain.Entities.Achievements.Results;

namespace MyGuides.Domain.Entities.Achievements.Converters
{
    public class ToAchievementResultConverter : ITypeConverter<List<Achievement>, List<AchievementResult>>
    {
        public List<AchievementResult> Convert(List<Achievement> source, List<AchievementResult> destination, ResolutionContext context)
        {
            destination = new List<AchievementResult>();

            foreach (var achievement in source)
            {
                var chievo = new AchievementResult()
                {
                    Name = achievement.Name,
                    Description = achievement.Description,
                    Hidden = achievement.Hidden,
                    Icon = achievement.Icon
                };

                if (achievement.Difficulty is not null)
                {
                    chievo.Difficulty = new Difficulty()
                    {
                        Name = achievement.Difficulty.Name,
                        Id = achievement.Difficulty.Id,
                        Image = achievement.Difficulty.Image
                    };
                }

                destination.Add(chievo);
            }

            return destination;
        }
    }
}
