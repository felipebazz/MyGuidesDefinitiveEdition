using AutoMapper;
using MyGuides.Domain.Entities.Achievements.Results;

namespace MyGuides.Domain.Entities.Achievements.Converters
{
    public class ToAchievementResultConverter : ITypeConverter<List<Achievement>, List<AchievementResult>>
    {
        public List<AchievementResult> Convert(List<Achievement> source, List<AchievementResult> destination, ResolutionContext context)
        {
            return source.Select(itens => new AchievementResult
            {
                Name = itens.Name,
                Description = itens.Description,
                Hidden = itens.Hidden,
                Icon = itens.Icon,
                Difficulty = itens.Difficulty == null ? null : new ResultDifficulty
                {
                    Name = itens.Difficulty.Name,
                    Id = itens.Difficulty.Id,
                    Image = itens.Difficulty.Image
                },
            }).ToList();
        }
    }
}
