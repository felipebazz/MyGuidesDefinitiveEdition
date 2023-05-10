namespace MyGuides.Domain.Entities.Achievements.Results
{
    public class AchievementResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public string Icon { get; set; }
        public ResultDifficulty? Difficulty { get; set; }
    }

    public class ResultDifficulty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
