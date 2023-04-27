using AutoMapper;
using MyGuides.Domain.Entities.Achievements.Results;
using Steam.Api.Clients.StoreApi.Responses;
using Steam.Api.Responses;

namespace MyGuides.Domain.Entities.Achievements.Converters
{
    public class ToAchievementResultConverter : ITypeConverter<List<Achievement>, List<AchievementResult>>
    {
        public List<AchievementResult> Convert(List<Achievement> source, List<AchievementResult> destination, ResolutionContext context)
        {
            //destination = new List<AchievementResult>();

            return source.Select(itens => new AchievementResult
            {
                Name = itens.Name,
                Description = itens.Description,
                Hidden = itens.Hidden,
                Icon = itens.Icon,
                Difficulty = itens.Difficulty == null ? null
                : new Difficulty
                {
                    Name = itens.Difficulty.Name,
                    Id = itens.Difficulty.Id,
                    Image = itens.Difficulty.Image
                },
            }).ToList();

            //foreach (var achievement in source)
            //{
            //    var chievo = new AchievementResult()
            //    {
            //        Name = achievement.Name,
            //        Description = achievement.Description,
            //        Hidden = achievement.Hidden,
            //        Icon = achievement.Icon
            //    };

            //    if (achievement.Difficulty is not null)
            //    {
            //        chievo.Difficulty = new Difficulty()
            //        {
            //            Name = achievement.Difficulty.Name,
            //            Id = achievement.Difficulty.Id,
            //            Image = achievement.Difficulty.Image
            //        };
            //    }

            //    destination.Add(chievo);
            //}

            //return destination;
        }
    }
}
